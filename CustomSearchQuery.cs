using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Cms.Shell.UI.Rest.ContentQuery;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using EPiServer.Shell.Search;
using EPiServer.Web.Routing;
namespace EPiServer.Templates.Alloy.UIExtensions.CustomSearch
{
    [ServiceConfiguration(typeof(IContentQuery))]
    public class CustomSearchQuery : ContentQueryBase
    {
        private readonly IContentRepository _contentRepository;
        private readonly SearchProvidersManager _searchProvidersManager;
        private readonly LanguageSelectorFactory _languageSelectorFactory;
        public CustomSearchQuery(
            IContentQueryHelper queryHelper,
            IContentRepository contentRepository,
            SearchProvidersManager searchProvidersManager,
            LanguageSelectorFactory languageSelectorFactory)
            : base(contentRepository, queryHelper)
        {
            _contentRepository = contentRepository;
            _searchProvidersManager = searchProvidersManager;
            _languageSelectorFactory = languageSelectorFactory;

        }
        /// <summary>        
        /// The key to trigger this query.        
        /// </summary>        
        public override string Name
        {
            get { return "CustomQuery"; }
        }

        protected override IEnumerable<IContent> GetContent(ContentQueryParameters parameters)
        {
            var queryText = HttpUtility.HtmlDecode(parameters.AllParameters["queryText"]);
            var searchQuery = new Query(queryText);
            var contentReferences = Enumerable.Empty<ContentReference>();
            var searchProvider = _searchProvidersManager.GetEnabledProvidersByPriority("CMS/Pages", true).FirstOrDefault();

            if (searchProvider != null)
            {
                contentReferences = searchProvider.Search(searchQuery).Select(result => ContentReference.Parse(result.Metadata["Id"])).Distinct();
            }
            return _contentRepository.GetItems(contentReferences, _languageSelectorFactory.AutoDetect(parameters.AllLanguages));
        }
    }
}