namespace Quotation.Application.Models {
    public abstract class BaseResponse {

        public abstract bool IsSuccess();
        public string Error { get; protected set; }

    }
}
