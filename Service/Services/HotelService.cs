using AutoMapper;
using Entity.Entites;
using Entity.Services;
using Entity.UnitOfWorks;
using Entity.ViewModels;

public class HotelService : IHotelService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public HotelService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HotelViewModel>> GetAll()
    {
        var list = await _uow.GetRepository<Hotel>().GetAllAsync();
        return _mapper.Map<List<HotelViewModel>>(list);
    }

    public async Task<HotelViewModel> Get(int id)
    {
        var hotel = await _uow.GetRepository<Hotel>().GetByIdAsync(id);
        if (hotel == null)
        {
            throw new KeyNotFoundException("Hotel not found");
        }
        return _mapper.Map<HotelViewModel>(hotel);
    }

    public Task Add(HotelViewModel model)
    {
        throw new NotImplementedException();
    }
}
