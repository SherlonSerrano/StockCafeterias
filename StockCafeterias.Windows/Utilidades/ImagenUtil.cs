using System.Drawing.Imaging;

namespace StockCafeterias.Windows.Utilidades;

public static class ImagenUtil
{
    public static byte[]? ImagenABytes(Image? imagen)
    {
        if (imagen == null) return null;

        using var ms = new MemoryStream();
        // Guardamos como PNG para preservar calidad y transparencia
        imagen.Save(ms, ImageFormat.Png);
        return ms.ToArray();
    }

    public static Image? BytesAImagen(byte[]? bytes)
    {
        if (bytes == null || bytes.Length == 0) return null;

        using var ms = new MemoryStream(bytes);
        return Image.FromStream(ms);
    }
}
