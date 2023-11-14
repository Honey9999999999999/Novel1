mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.log("HW");
  },

  GiveMePlayerData: function () {
    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
  },

  SaveExtern: function(date){
    var dateString = UTF8ToString(date);
    var myObj = JSON.parse(dateString);
    player.setData(myObj);
  },
  
  LoadExtern: function(){
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    });
  },
});