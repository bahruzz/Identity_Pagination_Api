using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Rooms;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository roomRepo,
                          IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(RoomCreateDto model)
        {
            await _roomRepo.CreateAsync(_mapper.Map<Room>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            var data = await _roomRepo.GetById((int)id);
            await _roomRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id,RoomEditDto model)
        {

            if (model == null) throw new ArgumentNullException();
            var data = await _roomRepo.GetById(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _roomRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<RoomDto>>(await _roomRepo.GetAllAsync());
        }

        public async Task<RoomDto> GetByIdAsync(int id)
        {
            return _mapper.Map<RoomDto>(await _roomRepo.GetById((int)id));
        }
    }
}
