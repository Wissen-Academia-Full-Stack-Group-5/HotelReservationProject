using AutoMapper;
using Data.Contexts;
using Entity.Entites;
using Entity.Repositories;
using Entity.Services;
using Entity.UnitOfWorks;
using Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
	public class RoomService : IRoomService
	{
		private readonly HotelDbContext _dbContext;
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;
		public RoomService(IUnitOfWork unitOfWork, IMapper mapper, HotelDbContext dbContext)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
			_dbContext = dbContext;
		}

		public Task Add(RoomViewModel model)
		{
			throw new NotImplementedException();
		}

		public async Task<RoomViewModel> Get(int id,int hotelid)
		{
			var room = await _dbContext.Rooms
			.Where(r => r.HotelId == hotelid && r.RoomId == id)
			.Select(r => new RoomViewModel
			{
				HotelId=hotelid,RoomId=r.RoomId
				// Diğer özellikler
			})
			.FirstOrDefaultAsync();

			return room;
		}

		public async Task<IEnumerable<RoomViewModel>> GetAll()
		{
			var list = await unitOfWork.GetRepository<Room>().GetAllAsync();
			return mapper.Map<List<RoomViewModel>>(list);
		}
	}
}
