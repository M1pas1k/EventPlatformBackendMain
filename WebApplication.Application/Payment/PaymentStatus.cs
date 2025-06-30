namespace WebApplication.Application.Payment
{
    public class PaymentStatus
    {
        public static string Pending => "pending";
        public static string WaitForCapture => "waiting_for_capture";
        public static string Succeeded => "succeeded";
    }
}
