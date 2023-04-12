using _1.DAL.Models;

namespace Assignment.IServices
{
    public interface IMaterialService
    {
        public bool CreateMaterial(Material p);
        public bool UpdateMaterial(Material p);
        public bool DeleteMaterial(Guid id);
        public List<Material> GetAllMaterials();
        public List<Material> GetMaterial5s();
        public Material GetMaterialById(Guid id);
        public List<Material> GetProductByName(string name);
    }
}
