namespace MApp.Common.Helpers;

public class PictureHelper
{
    private static string profilePicturesPath = Path.Combine("C:\\Users\\micha\\Pictures", "MAppProfilePictures");
    public static async Task<string> ConvertProfilePictureFromStringAndSave(string pictureString, int userID)
    {
        byte[] imageBytes = Convert.FromBase64String(pictureString);
        if (!Directory.Exists(profilePicturesPath))
            Directory.CreateDirectory(profilePicturesPath);

        string uniqueFileName = $"{userID}.jpg";
        string filePath = Path.Combine(profilePicturesPath, uniqueFileName);
        await File.WriteAllBytesAsync(filePath, imageBytes);
        return filePath;
    }
    public static async Task<string> ConvertProfilePictureToString(int userID)
    {
        var picturePath = Path.Combine(profilePicturesPath, $"{userID}.jpg");
        var profilePicture = string.Empty;
        if (File.Exists(picturePath))
        {
            var pictureBytes = await File.ReadAllBytesAsync(picturePath);
            profilePicture = Convert.ToBase64String(pictureBytes);
        }
        return profilePicture;
    }
}
