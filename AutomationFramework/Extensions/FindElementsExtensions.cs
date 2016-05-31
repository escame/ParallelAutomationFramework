using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;


namespace AutomationFrameWork.Extensions
{
    public static class FindElementExtensions
    {
        /// <summary>
        /// Find an element, waiting until a timeout is reached if necessary.
        /// </summary>
        /// <param name="context">The search context.</param>
        /// <param name="by">Method to find elements.</param>
        /// <param name="timeout">How many seconds to wait.</param>
        /// <param name="polling">How many seconds to research.</param>
        /// <param name="displayed">Require the element to be displayed?</param>
        /// <returns>The found element.</returns>
        public static IWebElement FindElement (this ISearchContext context, By by, uint timeout = 60,uint polling = 250, bool displayed = false)
        {
            var wait = new OpenQA.Selenium.Support.UI.DefaultWait<ISearchContext>(context);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(polling);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));           
            return wait.Until(ctx => {
                var elem = ctx.FindElement(by);
                if (displayed && !elem.Displayed)
                    return null;
                return elem;
            });
        }

        /// <summary>
        /// Find an element, waiting until a timeout is reached if necessary.
        /// </summary>
        /// <param name="context">The search context.</param>
        /// <param name="by">Method to find elements.</param>
        /// <param name="timeout">How many seconds to wait.</param>
        /// <param name="polling">How many seconds to research.</param>
        /// <param name="displayed">Require the element to be displayed?</param>
        /// <returns>The found element.</returns>
        public static ReadOnlyCollection<IWebElement> FindElements (this ISearchContext context, By by, uint timeout = 60, uint polling = 250)
        {
            var wait = new OpenQA.Selenium.Support.UI.DefaultWait<ISearchContext>(context);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(polling);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(ctx => {
                var elem = ctx.FindElements(by);
                if (elem.Count==0)
                    return null;
                return elem;
            });
        }
    }
}
