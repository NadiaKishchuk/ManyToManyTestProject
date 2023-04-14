using Microsoft.EntityFrameworkCore;
using Tests.PatrnersTestContext;
using Tests.PatrnersTestContext.Models;

//using (var cts = new ContextWihtEntity())
//{
//    cts.Partners.Add(new Partner() { Title = "patner title 1" });
//    cts.Partners.Add(new Partner()
//    {
//        Title = "patner title 1",
//        Streetcodes = new List<Streetcode>(){
//            new Streetcode() { Title="s1"} ,
//            new Streetcode() { Title="s2"} ,
//            new Streetcode() { Title="s3"} ,

//        }
//    });
//    cts.Partners.Add(new Partner() { Title = "patner title 1" });
//    cts.SaveChanges();
//}

// AsNoTracking method is used because it is in our project
using (var cts = new ContextWihtEntity())
{
    var streetcode = cts.Streetcodes.Add(new Streetcode() { Title = "for add" });

    cts.SaveChanges();

    Partner partner = cts.Set<Partner>().AsNoTracking().Include(s => s.Streetcodes)
        .FirstOrDefault(p => p.Streetcodes.Count() > 0);
    var fromDto = new Partner() { Id = partner.Id,
        Title = "updatedtitile", Streetcodes = new List<Streetcode>() };
    if (partner != null)
    {
        fromDto.Streetcodes = cts.Set<Streetcode>().AsNoTracking().Take(4).ToList();
        cts.Set<Partner>().Update(fromDto);
    }

    // await cts.Set<StreetcodePartner>().ForEachAsync(sp=> Console.WriteLine($"{sp.StreetcodeId} {sp.PartnerId}") );

    cts.SaveChanges();

}
