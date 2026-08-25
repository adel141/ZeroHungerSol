using AutoMapper;
using BLL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class AssignmentService
    {
        private readonly IMapper mapper;
        private readonly AssignmentRepo repo;
        public AssignmentService(IMapper _mapper, AssignmentRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }

        public List<AssignmentModel> GetAll()
        {
            var data = repo.GetAll();
            return mapper.Map<List<AssignmentModel>>(data);
        }

        public AssignmentModel GetById(int id)
        {
            var data = repo.GetById(id);
            return mapper.Map<AssignmentModel>(data);
        }

        public bool Add(AssignmentModel model)
        {
            var data = mapper.Map<DAL.EF.Table.Assignment>(model);
            repo.Add(data);
            return true;
        }

        public List<AssignmentModel> GetByEmployeeId(int employeeId)
        {
            var data = repo.GetByEmployeeId(employeeId);
            return mapper.Map<List<AssignmentModel>>(data);
        }

        public bool Update(int id,AssignmentModel model)
        {
            var data = repo.GetById(id);
            data = mapper.Map<DAL.EF.Table.Assignment>(model);
            return repo.Update(data);
        }
        public AssignmentModel GetByRequestId(int requestId)
        {
            var data = repo.GetByRequestId(requestId);

            if (data == null)
                return null;

            return mapper.Map<AssignmentModel>(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public bool UpdateStatus(int id, string status)
        {
            var data = repo.GetById(id);
            if (data == null)
            {
                return false;
            }
            if (status == "accept")
            {
                data.AcceptedAt= System.DateTime.Now;
                return repo.Update(data);
            }
            if (status == "Collect")
            {
                data.CollectedAt = System.DateTime.Now;
                return repo.Update(data);
            }
            if(status == "Distributed")
            {
                data.DistributedAt = System.DateTime.Now;
                return repo.Update(data);
            }

            return repo.Update(data);
        }
        public List<AssignmentModel> GetAssignmentsByEmployeeId(int employeeId)
        {
            var data = repo.GetAssignmentsByEmployeeId(employeeId);
            return mapper.Map<List<AssignmentModel>>(data);
        }
    }
}
