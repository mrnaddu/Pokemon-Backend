using AutoMapper;
using Pokemon_WebApi.Applications.Abstract;
using Pokemon_WebApi.Models.Dtos;
using Pokemon_WebApi.Models.Entities;
using Pokemon_WebApi.Models.Error;
using Pokemon_WebApi.Models.Response;
using Pokemon_WebApi.Repositories.Abastract;
using Pokemon_WebApi.Repository.Abastract;

namespace Pokemon_WebApi.Applications.Implementation;

public class PokemonService : IPokemonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<PokemonService> _logger;
    private readonly IFileService _fileService;
    public PokemonService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<PokemonService> logger,
        IFileService fileService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _fileService = fileService;
    }

    public async Task<ResponseValue<PokemonDto>> CreatePokemonAsync(
        CreateUpdatePokemonDto pokemon)
    {
        var data = _mapper.Map<Pokemon>(pokemon);
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
            var result = await _unitOfWork.Repository<Pokemon>().AddAsync(data);
            await _unitOfWork.SaveAsync();
            var value = _mapper.Map<Pokemon,PokemonDto>(result);
            return new ResponseValue<PokemonDto>
            {
                Message = ErrorMessage.SuccessResponse,
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

    public async Task<ResponseValue<PokemonDto>> DeletePokemonAsync(
        Guid id)
    {
        try
        {
            var data = await _unitOfWork.Repository<Pokemon>().Get(id);
            if (data != null)
            {
                data.IsDeleted = true;
                await _unitOfWork.SaveAsync();
            }
            var value = _mapper.Map<Pokemon,PokemonDto>(data);
            return new ResponseValue<PokemonDto>
            {
                Message = ErrorMessage.SuccessResponse,
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

    public Task<ResponseValue<List<PokemonDto>>> GetAllPokemonAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseValue<PokemonDto>> GetByIdPokemonAsync(
        Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseValue<PokemonDto>> UpdatePokemonAsync(
        Guid id,
        CreateUpdatePokemonDto pokemon)
    {
        throw new NotImplementedException();
    }
}
