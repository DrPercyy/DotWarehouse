using System;

namespace Warehouse.Core.Inventory.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}