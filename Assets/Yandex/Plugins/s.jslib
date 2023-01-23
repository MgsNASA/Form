mergeInto(LibraryManager.library, {

  

    ShowAdv: function() {
      ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          console.log("____close___");
        },
        onError: function(error) {
          // some action on error
        }
    }
})

    },
    RestartGameAdExtern:function(){
      
ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
       
        },
        onClose: () => {
          console.log('Video ad closed.');
           myGameInstance.SendMessage("GameManager","Continio");
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})




    },

    SaveExtern:function(data)  {

        var dateString =UTF8ToString(data);
        var myobj =JSON.parse(dateString);
        player.setData(myobj);
    },

    LoadExtern:function()
    { 
      player.getData().then(_data=>{

        const myJson =JSON.stringify(_data);
        myGameInstance.SendMessage('Progress','SetPlayerInfo',myJson);
      });
    },

SetToLeaderboard: function(value){

ysdk.getLeaderboards()
  .then(lb => {
    lb.setLeaderboardScore('Wave', value);
   
  });
}, 
   
});
