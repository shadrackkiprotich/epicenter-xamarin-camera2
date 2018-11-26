using Android.Media;
using Java.Nio;

namespace Camera2Basic.ExtentionMethods
{
    public static class ImageExtentions
    {
        public static byte[] ByteArray(this Image image)
        {
            foreach (var plane in image.GetPlanes())
            {
                ByteBuffer buffer = plane.Buffer;
                if (buffer != null)
                {
                    byte[] bytes = new byte[buffer.Remaining()];
                    buffer.Get(bytes);
                    image.Close();
                    return bytes;
                }
            }
            return new byte[0];
        }
        public static string ToBase64String(this Image image)
        {
             if (image == null)
                return "";
            return System.Convert.ToBase64String(image.ByteArray());
        }
    }
}