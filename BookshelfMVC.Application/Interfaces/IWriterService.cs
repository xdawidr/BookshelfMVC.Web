using BookshelfMVC.Application.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookshelfMVC.Application.Interfaces
{
    public interface IWriterService
    {
        ListWriterForListVm GetAllWritersForList(int pageSize, int pageNumber, string searchString);
        int AddWriter(NewWriterVm writer);
        void DeleteWriter(int id);
        WriterDetailsVm GetWriter(int id);
        NewWriterVm GetWriterToEdit(int id);
        void UpdateWriter(NewWriterVm model);
    }
}
