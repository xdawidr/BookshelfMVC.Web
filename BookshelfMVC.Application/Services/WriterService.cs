using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Publisher;
using BookshelfMVC.Application.ViewModels.Writer;
using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookshelfMVC.Application.Services
{
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepo;
        private readonly IMapper _mapper;

        public WriterService(IWriterRepository writerRepo, IMapper mapper)
        {
            _writerRepo = writerRepo;
            _mapper = mapper;
        }

        public int AddWriter(NewWriterVm writer)
        {
            var newWriter = _mapper.Map<Writer>(writer);
            return _writerRepo.AddWriter(newWriter);
        }

        public void DeleteWriter(int id)
        {
            _writerRepo.DeleteWriter(id);
        }

        public ListWriterForListVm GetAllWritersForList(int pageSize, int pageNumber, string searchString)
        {
            var writers = _writerRepo.GetAllWriters().Where(w => w.Name.StartsWith(searchString))
               .ProjectTo<WriterForListVm>(_mapper.ConfigurationProvider).ToList();
            var writersToShow = writers.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            var writerList = new ListWriterForListVm()
            {
                PageSize = pageSize,
                CurrentNumber = pageNumber,
                SearchString = searchString,
                Writers = writers,
                Count = writers.Count
            };

            return writerList;
        }

        public WriterDetailsVm GetWriter(int id)
        {
            var writer =  _writerRepo.GetWriter(id);
            return _mapper.Map<WriterDetailsVm>(writer);
        }

        public NewWriterVm GetWriterToEdit(int id)
        {
            var writer = _writerRepo.GetWriter(id);
            return _mapper.Map<NewWriterVm>(writer);
        }

        public void UpdateWriter(NewWriterVm model)
        {
            var writer = _mapper.Map<Writer>(model);
            _writerRepo.UpdateWriter(writer);
        }
    }
}
