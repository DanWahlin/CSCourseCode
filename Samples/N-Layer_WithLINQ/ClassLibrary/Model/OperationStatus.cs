using System;

namespace Model
{
    /// <summary>
    /// Summary description for OperationStatus
    /// </summary>
    public class OperationStatus
    {
        public OperationStatus() { }

        public OperationStatus(bool status, string message, Exception exp)
            : this(status, message, exp, Guid.Empty)
        {
        }

        public OperationStatus(bool status, string message, Exception exp, Guid insertedRowID)
        {
            this.Status = status;
            this.Message = message;
            this.Exception = exp;
            this.InsertedRowID = insertedRowID;
        }

        private string _Message;
        private Exception _Exception;
        private bool _Status;
        private Guid _InsertedRowID;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public Exception Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }

        public Guid InsertedRowID
        {
            get { return _InsertedRowID; }
            set { _InsertedRowID = value; }
        }
    }
}
