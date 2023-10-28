using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var result = await _unitOfWork.Repository<Pokemon>().AddAsync(data);
            await _unitOfWork.SaveAsync();
            var img = await _fileService.GetImageAsync(result.PokemonImage);
            var value = _mapper.Map<Pokemon,PokemonDto>(result);
            return new ResponseValue<PokemonDto>
            {
                Message = ErrorMessage.SuccessResponse,
                StatusCode = true,
                Value = value,
                ImgUrl = img
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
            //var img = _fileService.DeleteImage(data.PokemonImage);
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
            var data = await _unitOfWork.Repository<Pokemon>()
                .TableNoTracking
                .OrderBy(p => p.Id)
                .ToListAsync();
            var value = _mapper.Map<List<Pokemon>,List<PokemonDto>>(data);
            return new ResponseValue<List<PokemonDto>>()
            {
                Message= ErrorMessage.SuccessResponse,
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
            var data = await _unitOfWork.Repository<Pokemon>().Get(id);
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
            var data = await _unitOfWork.Repository<Pokemon>().UpdateAsync(id, map);
            var value = _mapper.Map<Pokemon, PokemonDto>(data);
            await _unitOfWork.SaveAsync();
            return new ResponseValue<PokemonDto>()
            {
                Message = ErrorMessage.SuccessResponse,
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
