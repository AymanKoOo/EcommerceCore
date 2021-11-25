using AyyBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Discounts;
using Web.DTOs;

namespace Web.Services
{
    public static class PaginationService
    {
        public static  TListModel PrepareToGrid<TListModel, TModel, TObject>(this TListModel listModel,PagedList<TObject> objectList,
            Func<IEnumerable<TModel>> dataFillFunction)

            where TListModel : BasePagedListModel<TModel>
            where TModel : class
        {
            if (listModel == null)
                throw new ArgumentNullException(nameof(listModel));
                listModel.Data = dataFillFunction?.Invoke();
                listModel.PageSize = objectList.PageSize;
                listModel.CurrentPage = objectList.CurrentPage;
                listModel.TotalPages = objectList.TotalPages;
                listModel.HasNext = objectList.HasNext;
                listModel.HasPrevious = objectList.HasPrevious;

            return listModel;
        }

    }
}
