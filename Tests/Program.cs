using Microsoft.EntityFrameworkCore;
using Tests;
using Tests.PatrnersTestContext;
using Tests.PatrnersTestContext.Models;
using Tests.Test2;

//using ( var context = new TestContext())
//{
//    context.Set<TagCodeIndex>().Add(new TagCodeIndex()
//    {
//        Code = new Code() { Title="code title"},
//        Tag = new Tag() { Name = "tag"}
//    });

//    context.SaveChanges();
//    Console.WriteLine( context.Codes.Count());
//}

//using (var context = new MyContext())
//{
//    ICollection<Comment> comments; 
//    foreach (var member in context.Members)
//    {
//        Console.WriteLine( member );
//        if (member.Comments != null)
//        {
//            foreach (var comment in member.Comments)
//            {
//                Console.WriteLine(comment);
//            }
//        }

//        Console.WriteLine();
//    }
//}
//Console.WriteLine( "\n" );
//using (var context = new MyContext())
//{
//    //foreach (var member in context.Set<Member>().Include(p => p.Comments))
//    //{
//    //    Console.WriteLine(member);
//    //    if (member.Comments != null)
//    //    {
//    //        foreach (var comment in member.Comments)
//    //        {
//    //            Console.WriteLine(comment);
//    //        }
//    //    }
//    //    Console.WriteLine();
//    //}
//    Console.WriteLine("\n" );

//    foreach (var member in context.Set<Member>().Include(p => p.MemberComments).Include(p=>p.Comments))
//    {
//        Console.WriteLine(member);
//        if (member.MemberComments != null)
//        {
//            foreach (var MemberComments in member.MemberComments)
//            {
//                Console.WriteLine(MemberComments);
//                Console.WriteLine( MemberComments.Member );
//                Console.WriteLine( MemberComments.Comment );
//            }
//        }
//        Console.WriteLine("\n\n");
//    }
//}

//using (var ctx = new TestContext())
//{
//    foreach(var code in ctx.Set<Code>().Include(c => c.TagCodeIndices))
//    {
//        Console.WriteLine( code);
//        if(code.TagCodeIndices !=null)
//       foreach(var ind in code.TagCodeIndices)
//        {
//            Console.WriteLine( ind );   
//        }
//        Console.WriteLine();
//    }
//}

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

using (var cts = new ContextWihtEntity())
{
    var streetcode = cts.Streetcodes.Add(new Streetcode() { Title = "for add" });

    cts.SaveChanges();

    Partner partner = cts.Set<Partner>().Include(s => s.Streetcodes)
        .FirstOrDefault(p => p.Streetcodes.Count() > 0);
    var fromDto = new Partner() { Id = partner.Id,
        Title = "updatedtitile", Streetcodes = new List<Streetcode>() };
    if (partner != null)
    {
        fromDto.Streetcodes = cts.Set<Streetcode>().Take(4).ToList();
        cts.Set<Partner>().Update(fromDto);
    }

    // await cts.Set<StreetcodePartner>().ForEachAsync(sp=> Console.WriteLine($"{sp.StreetcodeId} {sp.PartnerId}") );

    cts.SaveChanges();

}
