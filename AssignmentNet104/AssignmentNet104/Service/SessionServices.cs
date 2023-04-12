using _1.DAL.Models;
using Newtonsoft.Json;

namespace AssignmentNet104.Service
{
    public class SessionServices
    {
        public static List<Material> GetObjFromSession(ISession session, string key)
        {
            string jsonData = session.GetString(key); // lấy dữ liệu dạng string từ session
            if (jsonData == null)
            {
                return new List<Material>(); // Khởi tạo 1 list mới để chứa sp khi dữ liệu lấy ra null => Session chưa được tạo ra
            }
            else
            {
                // Nếu có dự liệu thì chuyển về dạng list
                var materials = JsonConvert.DeserializeObject<List<Material>>(jsonData);
                return materials;
            }
        }
        public static void SetObjToSession(ISession session, string key, object data)
        {
            var jsonData = JsonConvert.SerializeObject(data); // Chuyển đổi dữ liệu về jsonData
            session.SetString(key, jsonData); // ghi đè vào session
        }
        public static bool CheckObjList(Guid id, List<Material> materials)
        {
            return materials.Any(x => x.IdMaterial == id);
        }
    }
}
