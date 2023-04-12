using _1.DAL.Models;
using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Service
{
    public class MaterialService : IMaterialService
    {
        ShopDbContext _dbContext;
        public MaterialService()
        {
            _dbContext = new ShopDbContext();
        }
        public bool CreateMaterial(Material p)
        {
            try
            {
                _dbContext.Materials.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteMaterial(Guid id)
        {
            try
            {
                var temp = _dbContext.Materials.FirstOrDefault(c => c.IdMaterial == id);
                _dbContext.Materials.Remove(temp);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<Material> GetAllMaterials()
        {
            return _dbContext.Materials.ToList();
        }

        public List<Material> GetMaterial5s()
        {
            return _dbContext.Materials.Where(c => c.SoLuongTon >= 5).ToList();
        }

        public Material GetMaterialById(Guid id)
        {
            return _dbContext.Materials.FirstOrDefault(c => c.IdMaterial == id);
        }

        public List<Material> GetProductByName(string name)
        {
            return _dbContext.Materials.Where(c => c.Name == name).ToList();
        }

        public bool UpdateMaterial(Material p)
        {
            try
            {
                var temp = _dbContext.Materials.FirstOrDefault(c => c.IdMaterial == p.IdMaterial);
                temp.Status = p.Status;
                temp.Code = p.Code;
                temp.Name = p.Name;
                temp.Price = p.Price;
                temp.SoLuongTon = p.SoLuongTon;
                _dbContext.Materials.Update(temp);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
