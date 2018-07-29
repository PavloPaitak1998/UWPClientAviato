# UWPClientAviato
A Desktop Client App Aviato using WebAppAirlineDispatcher

For the previously written API (Airport), write a simple client using the desktop technology UWP. In short, all functionality from the previous Angular task should be implemented. The architecture of the application differs little from the client on Angular. There is a data view layer (Views), a business logic layer (when you write event handlers in .xaml.cs files) or an MVVM implementation), and a layer of working with the server (Services). To work with the server, use the already familiar HttpClient. All user actions must be asynchronous (use async / await).

What should be done:

* Make a menu that allows you to navigate between collections.
* When navigating to a menu item, the application must download the collection from the server.
* For each collection, write a page to display a list of elements with basic information (information depends on the particular collection, but you need to place 1-2 main fields in the list row).
* When you click on a list item, a block with detailed information about the list item should appear on the right.
* In the block with detailed information add the ability to edit and delete items.
* It is desirable to try responsive UI in UWP (if we reduce or increase the size of the window, the elements are rebuilt).
* If there is time and desire, then the use of MVVM will be a big plus. IMPORTANT! First, write a simple version (View - .xaml, and its handlers are .xaml.cs) for one collection. Evaluate your strength, if it's easy - try adding MVVM Light. If it does not work out, do not waste time, the most important thing (it will be enough to get 10) is to implement the functionality in any way.
