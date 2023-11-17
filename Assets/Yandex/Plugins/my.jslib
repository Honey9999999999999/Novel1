mergeInto(LibraryManager.library, {

  GiveMePlayerData: function () {
    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
  },

  SaveExtern: function(data){
    var dataString = UTF8ToString(data);
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

  ShowAdvExtern : function(){
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
     }
    })
  }
});