
    var jasonPicData = document.getElementById("jasonPicData").value;

    var photoList = JSON.parse(jasonPicData);


    var i = 0; // Start Point
    var images = []; // Images Array
    var time = 3000; // Time Between Switch

    console.log(photolist);

    for (var j = 0; j < photoList.length; j++) {
        images[j] = photoList[j].ImagePath;

    }


// Change Image
    function changeImg() {
        document.slide.src = images[i];

        // Check If Index Is Under Max
        if (i < images.length - 1) {
            // Add 1 to Index
            i++;
        } else {
            // Reset Back To O
            i = 0;
        }

        // Run function every x seconds
        setTimeout("changeImg()", time);
    }

// Run function when page loads
    window.onload = changeImg;

