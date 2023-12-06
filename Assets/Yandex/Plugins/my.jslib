mergeInto(LibraryManager.library, {

  GiveMePlayerData: function () {
    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
  },

  SaveExtern: function(data){
    var dataString = UTF8ToString(data);
    console.log("Data String:", dataString);
    var dataObject = JSON.parse(dataString);
    player.setData(dataObject);
  },
  
  LoadExtern: function(){
    player.getData().then(_data => {
      console.log("Player data:", _data);
      const myJSON = JSON.stringify(_data);
      myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    });
  },

  SaveLocalExtern: function(key, value){
    var dataString = UTF8ToString(value);
    console.log("Data String:", dataString);
    var dataObject = JSON.parse(dataString);

    ysdk.getStorage().then(safeStorage => {        
        safeStorage.setItem(key, dataObject);
        console.log(safeStorage.getItem(key));
    });
  },

  LoadLocalExtern: function(key){    
    ysdk.getStorage().then(safeStorage => {        
        const myJSON = JSON.stringify(safeStorage.getItem(key));
        console.log("my loading JSON:", myJSON);
        myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);        
    });
  },

  AutorizedExtern: function(){    
    ysdk.auth.openAuthDialog().then(() => {
      myGameInstance.SendMessage('AutoStartChecker', 'SetAutoState', "true");
    });
  },

  TryAuthExtern: function(){    
    gameIsLoaded = true;
    tryAuth();
  },

  ShowAdvExtern : function(){
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          myGameInstance.SendMessage('FlowStarter', 'Activate');
        },
        onError: function(error) {
          // some action on error
        }
     }
    })
  }
});