Parse-iOS-Xamarin-demo
======================

To get it working, create an account at Parse.com and add the following code in the Cloud Code section:


// Use Parse.Cloud.define to define as many cloud functions as you want.
// For example:
Parse.Cloud.define("hello", function(request, response) {
  response.success("Hello from woutercx!");
});
