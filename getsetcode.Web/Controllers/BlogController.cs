using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.GData.Blogger;
using Google.GData.Client;
using System.Text.RegularExpressions;
using getsetcode.Web.Models.Blog;
using getsetcode.Web.Extensions.ControllerExtensions;

namespace getsetcode.Web.Controllers
{
    public class BlogController : Controller
    {
        private Service __service;
        private Service _service
        {
            get
            {
                if (__service == null)
                {
                    __service = new Service("blogger", "getsetcode");
                    string username = "tom@getsetcode.com";
                    string password = "lgmpefrtcmrsucfb";

                    __service.Credentials = new GDataCredentials(username, password);
                }
                return __service;
            }
        }

        private string _baseUri = "http://www.blogger.com/feeds/8488298325400361717/posts/default";
        private string postUri(string id)
        {
            return string.Concat(_baseUri, "/", id);
        }

        [HttpGet]
        public JsonResult Items(int items, int startIndex)
        {
            FeedQuery query = new FeedQuery();
            query.Uri = new Uri(_baseUri);
            query.StartIndex = startIndex + 1; // Why do I have to plus 1 here? Is StartIndex not zero-based?
            query.NumberToRetrieve = items + 1;

            AtomFeed feed = null;
            feed = _service.Query(query);

            var bpl = new List<BlogPost>();
            bool moreAvailable = false;

            for (var i = 0; i < feed.Entries.Count; i++)
            {
                if (i == items)
                    moreAvailable = true;
                else
                {
                    var e = feed.Entries[i];
                    var bp = new BlogPost()
                    {
                        Title = e.Title.Text,
                        Content = e.Content.Content,
                        Date = e.Published,
                        ID = e.EditUri.Content.Substring(e.EditUri.Content.LastIndexOf('/') + 1),
                        FirstPost = (startIndex == 0 && i == 0)
                    };
                    bpl.Add(bp);
                }
            }

            return new JsonResult
            {
                Data = new
                {
                    Items = bpl.Count,
                    MoreAvailable = moreAvailable,
                    Last = bpl.Count > 0 ? Server.UrlEncode(bpl.Max(b => b.Date).ToString("yyyy/MM/dd HH:mm:ss")) : null,
                    Html = this.RenderPartialView(
                        "Blog/BlogPostList",
                        new BlogListData()
                        {
                            Posts = bpl
                        })
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json; charset=utf-8"
            };
        }

        public ActionResult Index()
        {
            return View(new Models.Shared.MainSideBarData());
        }

        public ActionResult IndexOLD(string id)
        {
            string uri;
            bool permalink = false;
            if (string.IsNullOrEmpty(id))
                uri = _baseUri;
            else
            {
                uri = postUri(id);
                permalink = true;
            }

            FeedQuery query = new FeedQuery();
            query.Uri = new Uri(uri);

            if (!permalink)
            {
                query.StartIndex = 0;
                query.NumberToRetrieve = 2;
            }

            AtomFeed feed = null;
            feed = _service.Query(query);

            var bpl = new List<BlogPost>();

            foreach (var e in feed.Entries)
            {
                var bp = new BlogPost()
                    {
                        Title = e.Title.Text,
                        Content = e.Content.Content,
                        Date = e.Published,
                        ID = e.EditUri.Content.Substring(e.EditUri.Content.LastIndexOf('/') + 1)
                    };
                bpl.Add(bp);
            }

            return View(new BlogListData()
                {
                    //SideBarData = new Models.Shared.MainSideBarData(),
                    Posts = bpl
                    //Posts = feed.Entries.Select(e => new BlogPost()
                    //{
                    //    Title = e.Title.Text,
                    //    Content = e.Content.Content,
                    //    Date = e.Published,
                    //    ID = Regex.Replace(e.Links.Single(l => l.Rel == "edit").HRef.ToString(), uri + "/", "")
                    //}).ToList()
                });
        }

        /*
         * 
            if (blogUri != null)
            {
                Console.WriteLine("\nRetrieving all blog posts");
                // Retrieve all posts in a blog
                FeedQuery query = new FeedQuery();
                Console.WriteLine("  Query URI: " + blogUri.ToString());
                query.Uri = "http://blog.getsetcode.com/feeds/posts/default";
                AtomFeed feed = service.Query(query);
                foreach (AtomEntry entry in feed.Entries)
                {
                    Console.WriteLine("  Entry Title: " + entry.Title.Text);
                }
            }
         */

//using System;
//using System.Text;
//using Google.GData.Client;
//using System.Net;
//using System.Xml;
//using System.Text.RegularExpressions;

//namespace BloggerDevSample
//{
//    class ConsoleSample
//    {
//        /** Lists the user's blogs. */
//        static void ListUserBlogs(Service service)
//        {
//            Console.WriteLine("\nRetrieving a list of blogs");
//            FeedQuery query = new FeedQuery();
//            // Retrieving a list of blogs
//            query.Uri = new Uri("http://www.blogger.com/feeds/default/blogs");
//            AtomFeed feed = null;
//            feed = service.Query(query);
//            foreach (AtomEntry entry in feed.Entries)
//            {
//                Console.WriteLine("  Blog title: " + entry.Title.Text);
//            }
//        }

//        /** Lists the user's blogs and returns the URI for posting new entries
//         * to the blog which the user selected.
//         */
//        static Uri SelectUserBlog(Service service)
//        {
//            Console.WriteLine("\nPlease select a blog on which to post.");
//            FeedQuery query = new FeedQuery();
//            // Retrieving a list of blogs
//            query.Uri = new Uri("http://www.blogger.com/feeds/default/blogs");
//            AtomFeed feed = service.Query(query);

//            // Publishing a blog post
//            Uri blogPostUri = null;
//            if (feed != null)
//            {
//                foreach (AtomEntry entry in feed.Entries)
//                {
//                    // Print out the title of the Blog
//                    Console.WriteLine("  Blog name: " + entry.Title.Text);
//                    Console.Write("  Post to this blog? (y/n): ");
//                    if (Console.ReadLine().Equals("y"))
//                    {
//                        // find the href in the link with a rel pointing to the blog's feed
//                        for (int i = 0; i < entry.Links.Count; i++)
//                        {
//                            if (entry.Links[i].Rel.Equals("http://schemas.google.com/g/2005#post"))
//                            {
//                                blogPostUri = new Uri(entry.Links[i].HRef.ToString());
//                                Console.WriteLine("  Your new posts will be sent to " + blogPostUri.AbsoluteUri.ToString());
//                            }
//                        }
//                        return blogPostUri;
//                    }
//                }
//            }
//            return blogPostUri;
//        }

//        /** Creates a new blog entry and sends it to the specified Uri */
//        static AtomEntry PostNewEntry(Service service, Uri blogPostUri)
//        {
//            Console.WriteLine("\nPublishing a blog post");
//            AtomEntry createdEntry = null;
//            if (blogPostUri != null)
//            {
//                // construct the new entry
//                AtomEntry newPost = new AtomEntry();
//                newPost.Title.Text = "Marriage!";
//                newPost.Content = new AtomContent();
//                newPost.Content.Content = "<div xmlns='http://www.w3.org/1999/xhtml'>" +
//                    "<p>Mr. Darcy has <em>proposed marriage</em> to me!</p>" +
//                    "<p>He is the last man on earth I would ever desire to marry.</p>" +
//                    "<p>Whatever shall I do?</p>" +
//                    "</div>";
//                newPost.Content.Type = "xhtml";
//                newPost.Authors.Add(new AtomPerson());
//                newPost.Authors[0].Name = "Elizabeth Bennet";
//                newPost.Authors[0].Email = "liz@gmail.com";

//                createdEntry = service.Insert(blogPostUri, newPost);
//                if (createdEntry != null)
//                {
//                    Console.WriteLine("  New blog post created with title: " + createdEntry.Title.Text);
//                }
//            }
//            return createdEntry;
//        }

//        /** Creates a new blog entry and sends it to the specified Uri */
//        static void PostAndDeleteNewDraftEntry(Service service, Uri blogPostUri)
//        {
//            Console.WriteLine("\nCreating a draft blog post");
//            AtomEntry draftEntry = null;
//            if (blogPostUri != null)
//            {
//                // construct the new entry
//                AtomEntry newPost = new AtomEntry();
//                newPost.Title.Text = "Marriage! (Draft)";
//                newPost.Content = new AtomContent();
//                newPost.Content.Content = "<div xmlns='http://www.w3.org/1999/xhtml'>" +
//                    "<p>Mr. Darcy has <em>proposed marriage</em> to me!</p>" +
//                    "<p>He is the last man on earth I would ever desire to marry.</p>" +
//                    "<p>Whatever shall I do?</p>" +
//                    "</div>";
//                newPost.Content.Type = "xhtml";
//                newPost.Authors.Add(new AtomPerson());
//                newPost.Authors[0].Name = "Elizabeth Bennet";
//                newPost.Authors[0].Email = "liz@gmail.com";
//                newPost.IsDraft = true;

//                draftEntry = service.Insert(blogPostUri, newPost);
//                if (draftEntry != null)
//                {
//                    Console.WriteLine("  New draft post created with title: " + draftEntry.Title.Text);
//                    // Delete the newly created draft entry
//                    Console.WriteLine("  Press enter to delete the draft blog post");
//                    Console.ReadLine();
//                    draftEntry.Delete();
//                }
//            }
//        }

//        /** Display the titles for all entries in the previously selected blog. */
//        static void ListBlogEntries(Service service, Uri blogUri)
//        {
//            if (blogUri != null)
//            {
//                Console.WriteLine("\nRetrieving all blog posts");
//                // Retrieve all posts in a blog
//                FeedQuery query = new FeedQuery();
//                Console.WriteLine("  Query URI: " + blogUri.ToString());
//                query.Uri = blogUri;
//                AtomFeed feed = service.Query(query);
//                foreach (AtomEntry entry in feed.Entries)
//                {
//                    Console.WriteLine("  Entry Title: " + entry.Title.Text);
//                }
//            }
//        }

//        /** Display title for entries in the blog in the hard coded date range. */
//        static void ListBlogEntriesInDateRange(Service service, Uri blogUri)
//        {
//            Console.WriteLine("\nRetrieving posts using query parameters");
//            // Retrieve all posts in a blog between Jan 1, 2006 and Apr 12, 2007
//            FeedQuery query = new FeedQuery();
//            query.Uri = blogUri;
//            query.MinPublication = new DateTime(2006, 1, 1);
//            query.MaxPublication = new DateTime(2007, 4, 12);
//            AtomFeed feed = service.Query(query);
//            foreach (AtomEntry entry in feed.Entries)
//            {
//                Console.WriteLine("  Entry Title: " + entry.Title.Text);
//            }
//        }

//        /** Change the contents of the newly created blog entry. */
//        static AtomEntry EditEntry(AtomEntry toEdit)
//        {
//            Console.WriteLine("\nUpdating post");
//            // Edit the new entry
//            if (toEdit != null)
//            {
//                toEdit.Title.Text = "Marriage Woes!";
//                Console.WriteLine("  Press enter to update");
//                Console.ReadLine();
//                toEdit = toEdit.Update();
//            }
//            return toEdit;
//        }

//        /** Delete the specified blog entry. */
//        static void DeleteEntry(AtomEntry toDelete)
//        {
//            Console.WriteLine("\nDeleting post");
//            // Delete the edited entry
//            if (toDelete != null)
//            {
//                Console.WriteLine("  Press enter to delete the new blog post");
//                Console.ReadLine();
//                toDelete.Delete();
//            }
//        }

//        /** Get the comments feed URI for the desired blog entry. */
//        static Uri SelectBlogEntry(Service service, Uri blogPostUri)
//        {
//            Console.WriteLine("\nPlease select a blog entry on which to comment.");
//            FeedQuery query = new FeedQuery();
//            query.Uri = blogPostUri;
//            AtomFeed feed = service.Query(query);
//            Uri commentPostUri = null;

//            if (feed != null)
//            {
//                foreach (AtomEntry entry in feed.Entries)
//                {
//                    // Print out the title of the Blog
//                    Console.WriteLine("  Blog entry title: " + entry.Title.Text);
//                    Console.Write("  Post a comment on this entry? (y/n): ");

//                    if (Console.ReadLine().Equals("y"))
//                    {
//                        // Create the Post URL for adding a comment by finding this entry's id number.

//                        // Find the href in the link with a rel pointing to the blog's feed.
//                        for (int i = 0; i < entry.Links.Count; i++)
//                        {
                            
//                            if (entry.Links[i].Rel == "edit")
//                            {
//                                string commentUriStart = Regex.Replace(blogPostUri.ToString(), "/posts/default", "");
//                                string selfLink = entry.Links[i].HRef.ToString();
//                                string entryId = Regex.Replace(selfLink, blogPostUri.ToString() + "/", "");
//                                // Build the comment URI from the blog id in and the entry id.
//                                commentPostUri = new Uri(commentUriStart + "/" + entryId + "/comments/default");
//                                Console.WriteLine("  Your new comments will be sent to " + commentPostUri.ToString());
//                                return commentPostUri;
//                            }
//                        }
//                    }
//                }
//            }

//            return commentPostUri;
//        }

//        static AtomEntry PostNewComment(Service service, Uri commentPostUri)
//        {
//            Console.WriteLine("\nCommenting on a blog post");
//            AtomEntry postedComment = null;
//            if (commentPostUri != null)
//            {
//                // Add a comment.
//                AtomEntry comment;
//                comment = new AtomEntry();
//                comment.Title.Text = "This is my first comment";
//                comment.Content.Content = "This is my first comment";
//                comment.Authors.Add(new AtomPerson());
//                comment.Authors[0].Name = "Blog Author Name";
//                postedComment = service.Insert(commentPostUri, comment);
//                Console.WriteLine("  Result's title: " + postedComment.Title.Text);
//            }
//            return postedComment;
//        }

//        static void ListEntryComments(Service service, Uri commentUri)
//        {
//            if (commentUri != null)
//            {
//                Console.WriteLine("\nRetrieving all blog post comments");
//                // Retrieve all comments on a blog entry
//                FeedQuery query = new FeedQuery();
//                Console.WriteLine("  Query URI: " + commentUri.ToString());
//                query.Uri = commentUri;
//                AtomFeed feed = service.Query(query);
//                foreach (AtomEntry entry in feed.Entries)
//                {
//                    Console.WriteLine("  Comment Title: " + entry.Title.Text);
//                }
//            }
//        }

//        static void DeleteComment(AtomEntry commentEntry)
//        {
//            Console.WriteLine("\nDeleting the comment");
//            if (commentEntry != null)
//            {
//                // Delete the comment.
//                Console.WriteLine("  Press enter to delete the new comment post");
//                Console.ReadLine();
//                commentEntry.Delete();
//            }
//        }

//        static void Main(string[] args)
//        {
//            Service service = new Service("blogger", "blogger-example");

//            // ClientLogin using username/password authentication
//            string username;
//            string password;
//            if (args.Length != 2)
//            {
//                Console.WriteLine("Usage: BloggerDevSample.exe <username> <password>");
//                return;
//            }
//            else
//            {
//                username = args[0];
//                password = args[1];
//            }

//            service.Credentials = new GDataCredentials(username, password);

//            ListUserBlogs(service);
//            Uri blogPostUri = SelectUserBlog(service);
//            AtomEntry createdEntry = PostNewEntry(service, blogPostUri);
//            PostAndDeleteNewDraftEntry(service, blogPostUri);
//            ListBlogEntries(service, blogPostUri);
//            ListBlogEntriesInDateRange(service, blogPostUri);
//            AtomEntry editedEntry = EditEntry(createdEntry);
//            DeleteEntry(editedEntry);
//            Uri commentPostUri = SelectBlogEntry(service, blogPostUri);
//            AtomEntry commentEntry = PostNewComment(service, commentPostUri);
//            ListEntryComments(service, commentPostUri);
//            DeleteComment(commentEntry);

//            Console.WriteLine("Press enter to quit");
//            Console.ReadLine();
//        }
//    }
//}
    }
}
