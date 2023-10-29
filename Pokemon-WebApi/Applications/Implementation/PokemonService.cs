using AutoMapper;
using Pokemon_WebApi.Applications.Abstract;
using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Models.Messages;
using Pokemon_WebApi.Models.Response;
using Pokemon_WebApi.Repositories.Abastract;
using Pokemon_WebApi.Repository.Abastract;

namespace Pokemon_WebApi.Applications.Implementation;

public class PokemonService 
    : IPokemonService
{
    private readonly IPokemonRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<PokemonService> _logger;
    private readonly IFileService _fileService;
    public PokemonService(
        IPokemonRepository repository,
        IMapper mapper,
        ILogger<PokemonService> logger,
        IFileService fileService)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
        _fileService = fileService;
    }

    public async Task<ResponseValue<PokemonDto>> CreatePokemonAsync(
        CreatePokemonDto pokemon)
    {
        var data = _mapper.Map<CreatePokemonDto,Pokemon>(pokemon);
        try
        {
            if(data.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(pokemon.ImageFile);
                if(fileResult != null)
                {
                    data.PokemonImage = fileResult.Item2; // Getting name of image
                }
            }
            var name = await _repository.FindByNameAsync(
                data.PokemonName);// Check the Name
            if(name == null) 
            {
                data.PokemonImageUrl = await _fileService.GetImageAsync(
                    data.PokemonImage); // // Getting ImageUrl
                var result = await _repository.CreateAsync(data);
                var value = _mapper.Map<Pokemon, PokemonDto>(result);
                return new ResponseValue<PokemonDto>
                {
                    Message = ResponseMessage.SuccessfullyInserted,
                    StatusCode = true,
                    Value = value
                };
            }
            else
            {
                return new ResponseValue<PokemonDto>
                {
                    Message = ResponseMessage.NameError,
                    StatusCode = false,
                    Value = null                
                };
            }      
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<ResponseValue<PokemonDto>> DeletePokemonAsync(
        Guid id)
    {
        try
        {
            var data = await _repository.DeleteAsync(id);
            _fileService.DeleteImage(data.PokemonImage); // Delete Image
            var value = _mapper.Map<Pokemon,PokemonDto>(data);
            return new ResponseValue<PokemonDto>
            {
                Message = ResponseMessage.SuccessfullyDeleted,
                StatusCode = true,
                Value = value
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<ResponseValue<List<PokemonDto>>> GetAllPokemonAsync()
    {
        try
        {
            var data = await _repository.GetAllAsync();
            var value = _mapper.Map<List<Pokemon>,List<PokemonDto>>(data);
            if(value != null && value.Count > 0)
            {
                value.ForEach(async x =>
                {
                    x.PokemonImageUrl =  
                    await _fileService.GetImageAsync(x.PokemonImage); // Getting ImageUrl
                });
            }
            return new ResponseValue<List<PokemonDto>>()
            {
                Message= ResponseMessage.FoundAllData,
                StatusCode = true,
                Value = value
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<ResponseValue<PokemonDto>> GetByIdPokemonAsync(
        Guid id)
    {
        try
        {
            var data = await _repository.GetAsync(id);
            if (data != null)
            {
                var value = _mapper.Map<Pokemon,PokemonDto>(data);
                return new ResponseValue<PokemonDto>()
                {
                    Value = value,
                    StatusCode = true,
                    Message = ResponseMessage.FoundTheData
                };
            }
            else
                return new ResponseValue<PokemonDto>()
                {
                    Value = null,
                    StatusCode = false,
                    Message = ResponseMessage.CouldNotFoundTheData
                };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<ResponseValue<PokemonDto>> UpdatePokemonAsync(
        Guid id,
        UpdatePokemonDto pokemon)
    {
        var map = _mapper.Map<UpdatePokemonDto, Pokemon>(pokemon);
        try
        {
            if (map.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(pokemon.ImageFile);
                if (fileResult != null)
                {
                    map.PokemonImage = fileResult.Item2; // Getting name of image
                }
            }
            map.PokemonImageUrl = await _fileService.GetImageAsync(
                    map.PokemonImage); // Getting ImageUrl
            var data = await _repository.UpdateAsync(id, map);
            var value = _mapper.Map<Pokemon, PokemonDto>(data);
            return new ResponseValue<PokemonDto>()
            {
                Message = ResponseMessage.SuccessfullyUpdated,
                StatusCode = true,
                Value = value
            };
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}
