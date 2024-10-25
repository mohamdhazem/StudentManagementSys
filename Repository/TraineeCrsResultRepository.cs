using MvcDay2Task.Models;

namespace MvcDay2Task.Repository
{
    public class TraineeCrsResultRepository : ITraineeCrsResultRepository
    {
        private readonly Context context;
        public TraineeCrsResultRepository(Context context)
        {
            this.context = context;
        }

        public void Add(CrsResult entity)
        {
            context.crsResults.Add(entity);
        }

        public void Delete(CrsResult entity)
        {
            context.crsResults.Remove(entity);
        }

        public List<CrsResult> GetAll()
        {
            return context.crsResults.ToList();
        }

        public CrsResult? GetById(int id)
        {
            CrsResult? crsResult = context.crsResults.FirstOrDefault(c => c.id == id);
            return crsResult;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(CrsResult entity)
        {
            context.crsResults.Update(entity);
        }
    }
}
