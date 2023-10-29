using AutoMapper;
using Pokemon_WebApi.Applications.Abstract;
using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Models.Error;
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
                    data.PokemonImage = fileResult.Item2; // getting name of image
                }
            }
            var name = await _repository.FindByNameAsync(data.PokemonName);
            if(name == null) 
            {
                var result = await _repository.CreateAsync(data);
                var img = await _fileService.GetImageAsync(result.PokemonImage);
                var value = _mapper.Map<Pokemon, PokemonDto>(result);
                return new ResponseValue<PokemonDto>
                {
                    Message = ErrorMessage.SuccessResponse,
                    StatusCode = true,
                    Value = value,
                    ImgUrl = img
                };
            }
            else
            {
                return new ResponseValue<PokemonDto>
                {
                    Message = ErrorMessage.NameError,
                    StatusCode = false,
                    Value = null,
                    ImgUrl = null
                    
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
            var img = _fileService.DeleteImage(data.PokemonImage);
            var value = _mapper.Map<Pokemon,PokemonDto>(data);
            return new ResponseValue<PokemonDto>
            {
                Message = ErrorMessage.SuccessResponse,
                StatusCode = true,
                Value = value,
                ImgUrl = null
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
            return new ResponseValue<List<PokemonDto>>()
            {
                Message= ErrorMessage.SuccessResponse,
                StatusCode = true,
                Value = value,
                ImgUrl = null
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
                var img = await _fileService.GetImageAsync(data.PokemonImage);
                var value = _mapper.Map<Pokemon,PokemonDto>(data);
                return new ResponseValue<PokemonDto>()
                {
                    Value = value,
                    StatusCode = true,
                    Message = ErrorMessage.SuccessResponse,
                    ImgUrl = img
                };
            }
            else
                return new ResponseValue<PokemonDto>()
                {
                    Value = null,
                    StatusCode = false,
                    Message = ErrorMessage.InternalServerError
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
                    map.PokemonImage = fileResult.Item2; // getting name of image
                }
            }
            var data = await _repository.UpdateAsync(id, map);
            var img = await _fileService.GetImageAsync(data.PokemonImage);
            var value = _mapper.Map<Pokemon, PokemonDto>(data);
            return new ResponseValue<PokemonDto>()
            {
                Message = ErrorMessage.SuccessResponse,
                StatusCode = true,
                Value = value,
                ImgUrl = img
            };
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}
