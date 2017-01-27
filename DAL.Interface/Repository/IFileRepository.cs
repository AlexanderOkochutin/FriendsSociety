﻿using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IFileRepository:IRepository<DalFile>
    {
        DalFile GetByName(string name);
    }
}
