﻿using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades.Interfaces;

public interface IFacade<TEntity, TListModel, TDetailModel>
    where TEntity : class, IEntity
    where TListModel : IModel
    where TDetailModel : class, IModel
{
    Task DeleteAsync(Guid id);
    Task<TDetailModel?> GetAsync(Guid id);
    Task<IEnumerable<TListModel>> GetAsync();
    Task<TDetailModel> SaveAsync(TDetailModel model);
    //TODO: sorty by se daly asi udelat genericky
    //IEnumerable<TListModel> Sort(IEnumerable<TListModel> models, string sortBy, bool descending);
}
