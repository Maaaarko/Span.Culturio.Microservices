using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Core.Models.Packages;
using Span.Culturio.Packages.Data;
using Span.Culturio.Packages.Data.Entities;

namespace Span.Culturio.Packages.Services {
    public class PackageService : IPackageService {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PackageService(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PackageDto> CreatePackageAsync(CreatePackageDto createPackageDto) {
            var createPackageItemsDto = createPackageDto.PackageItems;

            var package = _mapper.Map<Package>(createPackageDto);
            var packageItems = _mapper.Map<List<PackageItem>>(createPackageItemsDto);

            await _context.AddAsync(package);
            await _context.SaveChangesAsync();

            packageItems.ForEach(x => x.PackageId = package.Id);

            await _context.AddRangeAsync(packageItems);
            await _context.SaveChangesAsync();

            var packageItemsDto = _mapper.Map<IEnumerable<PackageItemDto>>(packageItems);

            var packageDto = _mapper.Map<PackageDto>(package);
            packageDto.CultureObjects = packageItemsDto;

            return packageDto;
        }

        public async Task<List<PackageDto>> GetPackagesAsync() {
            var packages = await _context.Packages.ToListAsync();
            var packageDtos = _mapper.Map<List<PackageDto>>(packages);

            packageDtos.ForEach(x => {
                var packageItems = _context.PackageItems.Where(y => y.PackageId == x.Id).ToList();
                var packageItemDtos = _mapper.Map<List<PackageItemDto>>(packageItems);
                x.CultureObjects = packageItemDtos;
            });

            return packageDtos;
        }
    }
}
