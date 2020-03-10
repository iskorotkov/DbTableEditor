using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbTableEditor.BlazorApp.Data
{
    public class SpaceshipsProvider
    {
        private SpaceshipsContext _context;

        public SpaceshipsProvider(SpaceshipsContext context)
        {
            _context = context;
        }

        public IEnumerable<Spaceship> LoadAll()
        {
            return _context.Spaceships;
            //.Include(s => s.Shipyard)
            //.Include(s => s.Fleet);
        }

        public async Task Save(Spaceship ship)
        {
            _context.Attach(ship);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Remove(IEnumerable<Spaceship> ships)
        {
            _context.RemoveRange(ships);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
