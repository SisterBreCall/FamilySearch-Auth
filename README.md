
# Unity ECS (Entity Component System) C# FamilySearch Authenticator

- Works with Unity 6 Beta (6000.0.0b12)
- Builds for PC, Mac, and Web Platforms
- Includes callback.html and index.html
- Gets authentication code, access token, id token, and information on current user.
- Decodes JWT id token
- Gets 4 generations of ancestors for current user and create individual entities for each ancestor.

# How To Setup Project with FamilySearch API Key

1. Open file in project at Assets/Scripts/Systems/CreateFSEntity.cs. (https://github.com/SisterBreCall/FamilySearch-Auth/blob/main/Assets/Scripts/Systems/CreateFSEntity.cs)
2. Set devEnvironment variable to Integration, Beta, or Production.
3. Set clientID variable with FamilySearch API key.
4. If building for web platform, set WebCallbackLocation variable to where the URL is for the callback.html file in your web directory.

# How To Build for Web Platform
1. Under Buld Profiles, under Platforms click Web, and click Switch Platform
2. Click Build
3. Set build directory to where you want the web build to go.
4. Modify index.html in build directory to the following where comments indicate to add variables and function:

      // !Add this variable to index.html
      var myGameInstance = null;

      var script = document.createElement("script");
      script.src = loaderUrl;
      script.onload = () => {
        createUnityInstance(canvas, config, (progress) => {
          progressBarFull.style.width = 100 * progress + "%";
        }).then((unityInstance) => {
          // !Add this to index.html
          myGameInstance = unityInstance;
          loadingBar.style.display = "none";
        }).catch((message) => {
          alert(message);
        });
      };
      document.body.appendChild(script);

     // !Add this entire function to index.html
     function StartOAuth(authorizationRequest) {
       window.addEventListener('message', function (e) {
       // !Make sure to set myGameInstance SendMessage function to Game Object with script attached and function to call to receive callback data.
       myGameInstance.SendMessage("GameManager", "GetAuthResultsWeb", e.data);
       }, false);

       var childWindow;
       const childWindowName = "Authenticate";
       childWindow = window.open(authorizationRequest, childWindowName);

       childWindow.focus();
   
5. Upload build directory to web server directory.
6. Make sure callback.html is in location for redirect url set by FamilySearch.
