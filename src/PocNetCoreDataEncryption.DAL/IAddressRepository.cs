﻿using Microsoft.EntityFrameworkCore;
using PocNetCoreDataEncryption.Domain.Entities;

namespace PocNetCoreDataEncryption.DAL
{
    public interface IAddressRepository : IRepository<Address>
    {
        
    }

    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(Context context) : base((DbContext) context)
        {
        }
    }
}