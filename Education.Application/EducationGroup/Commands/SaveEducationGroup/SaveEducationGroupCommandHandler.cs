using AutoMapper;
using Education.Domain;
using Education.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.EducationGroup.Commands.SaveEducationGroup
{
    public class SaveEducationGroupCommandHandler : IRequestHandler<SaveEducationGroupCommand, SaveEducationGroupCommandResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;
        private readonly EducationCacheHelper educationCacheHelper;
        public SaveEducationGroupCommandHandler(IUnitOfWork uow, ICacheService cache, IMapper mapper)
        {
            _uow = uow;
            _cache = cache;
            _mapper = mapper;
            educationCacheHelper = new EducationCacheHelper(_uow, _cache,_mapper);
        }

        public async Task<SaveEducationGroupCommandResult> Handle(SaveEducationGroupCommand request, CancellationToken cancellationToken)
        {
            var educationGroup = GetEducationGroup(request);

            using (var transaction = _uow.TransactionHelper)
            {
                transaction.BeginTransaction();

                int? educationGroupId = request.EducationGroupId;

                if (educationGroupId.HasValue)
                    await _uow.EducationGroup.Update(educationGroup);
                else
                    await _uow.EducationGroup.Add(educationGroup);

                _uow.SaveChangesAsync();

                transaction.Complete();
            }

            await educationCacheHelper.UpdateCache();
            return new SaveEducationGroupCommandResult();
        }


        private tb_EducationGroup GetEducationGroup(SaveEducationGroupCommand request)
        {
            int? educationGroupId = request.EducationGroupId;

            tb_EducationGroup educationGroup = new tb_EducationGroup();
            if (educationGroupId.HasValue)
            {
                educationGroup = _uow.EducationGroup.GetById(educationGroupId.Value).Result;
                if (educationGroup == null)
                    throw new Exception("Error:EducationGroupNotFound");

            }

            _mapper.Map(request, educationGroup);

            return educationGroup;
        }
    }
}
