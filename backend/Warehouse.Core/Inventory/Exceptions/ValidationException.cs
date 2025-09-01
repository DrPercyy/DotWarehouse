using System;

namespace Warehouse.Core.Inventory.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}