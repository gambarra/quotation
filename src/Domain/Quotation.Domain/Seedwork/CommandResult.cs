using System;
using System.Collections.Generic;
using System.Text;

namespace Quotation.Domain.Seedwork {
    public class CommandResult<T> where T : Entity {


        private CommandResult(T entity) {
            this.entity = entity;
            this.IsSuccess = true;
        }

        public bool IsSuccess { get; private set; }
        public IList<string> Erros { get; private set; }
        private readonly T entity;

        public T Value() {
            return entity;
        }

        internal void AddError(string error) {
            if (this.Erros == null)
                this.Erros = new List<string>();
            this.Erros.Add(error);
            this.IsSuccess = false;
        }

        static internal CommandResult<T> Fail(T entity, string error) {
            var result = new CommandResult<T>(entity);
            result.AddError(error);
            return result;
        }

        static internal CommandResult<T> Success(T entity) => new CommandResult<T>(entity);

        
    }
}
