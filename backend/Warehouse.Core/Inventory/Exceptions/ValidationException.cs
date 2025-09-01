//file: backend/Warehouse.Core/Inventory/Exceptions/ValidationException.cs

using System;

namespace Warehouse.Core.Inventory.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}