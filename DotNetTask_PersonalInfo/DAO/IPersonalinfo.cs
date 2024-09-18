using DotNetTask_PersonalInfo.Models;

namespace DotNetTask_PersonalInfo.DAO
{
    public interface IPersonalinfo
    {
        Task<int> InsertInfo(PersonalInformation info);
        Task<PersonalInformation> GetInsertInfo(int id);
        Task<List<PersonalInformation>> GetPersonalInfo();
        Task<int> UpdateInfo(int id, string name);
        Task<int> DeleteInfo(int id);
    }
}
