using CloudinaryDotNet.Actions;

namespace RunGroupWebApp.Interface
{
    public interface IPhotoService
    {
        //IForm file tüm uzantılarda dosya yüklemeyi sağlıyor ? ImageUploadResult için cloudinarydotnet package indirildi
        Task<ImageUploadResult> AddPhotoSync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string id);
    }
}
