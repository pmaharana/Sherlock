let mappy;
let infowindow;
let messagewindow;
let newmarker;





function initMap() {

    let uluru = { lat: 27.771344, lng: -82.635745 };
    mappy = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: uluru,
        mapTypeId: google.maps.MapTypeId.ROADMAP, styles:
        [{ "elementType": "geometry", "stylers": [{ "color": "#ebe3cd" }] },
            { "elementType": "labels.text.fill", "stylers": [{ "color": "#523735" }] },
            { "elementType": "labels.text.stroke", "stylers": [{ "col or": "#f5f1e6" }] },
            { "featureType": "administrative", "elementType": "geometry.stroke", "stylers": 
                [{ "color": "#c9b2a6" }]
            }, { "featureType": "administrative.land_parcel", "elementType": "geometry.stroke", "stylers": [{ "color": "#dcd2be" }] },
            { "featureType": "administrative.land_parcel", "elementType": "labels.text.fill", "stylers": 
                [{ "color": "#ae9e90" }] }, { "featureType": "landscape.natural", "elementType": "geometry", "stylers": [{ "color": "#dfd2ae" }] }, { "featureType": "poi", "elementType": "geometry", "stylers": [{ "color": "#dfd2ae" }] }, { "featureType": "poi", "elementType": "labels.text.fill", "stylers": [{ "color": "#93817c" }] }, { "featureType": "poi.business", "stylers": [{ "visibility": "off" }] }, { "featureType": "poi.park", "elementType": "geometry.fill", "stylers": [{ "color": "#a5b076" }] }, { "featureType": "poi.park", "elementType": "labels.text.fill", "stylers": [{ "color": "#447530" }] }, { "featureType": "road", "stylers": [{ "visibility": "simplified" }] }, { "featureType": "road", "elementType": "geometry", "stylers": [{ "color": "#f5f1e6" }] }, { "featureType": "road", "elementType": "labels", "stylers": [{ "visibility": "simplified" }] }, { "featureType": "road.arterial", "elementType": "geometry", "stylers": [{ "color": "#fdfcf8" }] }, { "featureType": "road.highway", "elementType": "geometry", "stylers": [{ "color": "#f8c967" }] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "color": "#e9bc62" }] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry", "stylers": [{ "color": "#e98d58" }] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "color": "#db8555" }] }, { "featureType": "road.local", "elementType": "labels.text.fill", "stylers": [{ "color": "#806b63" }] }, { "featureType": "transit", "stylers": [{ "visibility": "off" }] }, { "featureType": "transit.line", "elementType": "geometry", "stylers": [{ "color": "#dfd2ae" }] }, { "featureType": "transit.line", "elementType": "labels.text.fill", "stylers": [{ "color": "#8f7d77" }] }, { "featureType": "transit.line", "elementType": "labels.text.stroke", "stylers": [{ "color": "#ebe3cd" }] }, { "featureType": "transit.station", "elementType": "geometry", "stylers": [{ "color": "#dfd2ae" }] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "color": "#b9d3c2" }] }, { "featureType": "water", "elementType": "labels.text.fill", "stylers": [{ "color": "#92998d" }] }]
    });

    talkToServer();

}


   
     



function geoMap() {
    let mapuu = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 27.771344, lng: -82.635745 },
        zoom: 15
    });
    let infoWindow = new google.maps.InfoWindow;

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            let pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            infoWindow.setPosition(pos);
            infoWindow.setContent('Location found.');
            infoWindow.open(mapuu);
            map.setCenter(pos);
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}


function initMapAuth() {

    let ulur = { lat: 27.771344, lng: -82.635745 };
    mappy = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: ulur,
        mapTypeId: google.maps.MapTypeId.ROADMAP, styles: [{ "elementType": "geometry", "stylers": [{ "color": "#ebe3cd" }] }, { "elementType": "labels.text.fill", "stylers": [{ "color": "#523735" }] }, { "elementType": "labels.text.stroke", "stylers": [{ "color": "#f5f1e6" }] }, { "featureType": "administrative", "elementType": "geometry.stroke", "stylers": [{ "color": "#c9b2a6" }] }, { "featureType": "administrative.land_parcel", "elementType": "geometry.stroke", "stylers": [{ "color": "#dcd2be" }] }, { "featureType": "administrative.land_parcel", "elementType": "labels.text.fill", "stylers": [{ "color": "#ae9e90" }] }, { "featureType": "landscape.natural", "elementType": "geometry", "stylers": [{ "color": "#dfd2ae" }] }, { "featureType": "poi", "elementType": "geometry", "stylers": [{ "color": "#dfd2ae" }] }, { "featureType": "poi", "elementType": "labels.text.fill", "stylers": [{ "color": "#93817c" }] }, { "featureType": "poi.business", "stylers": [{ "visibility": "off" }] }, { "featureType": "poi.park", "elementType": "geometry.fill", "stylers": [{ "color": "#a5b076" }] }, { "featureType": "poi.park", "elementType": "labels.text.fill", "stylers": [{ "color": "#447530" }] }, { "featureType": "road", "stylers": [{ "visibility": "simplified" }] }, { "featureType": "road", "elementType": "geometry", "stylers": [{ "color": "#f5f1e6" }] }, { "featureType": "road", "elementType": "labels", "stylers": [{ "visibility": "simplified" }] }, { "featureType": "road.arterial", "elementType": "geometry", "stylers": [{ "color": "#fdfcf8" }] }, { "featureType": "road.highway", "elementType": "geometry", "stylers": [{ "color": "#f8c967" }] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "color": "#e9bc62" }] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry", "stylers": [{ "color": "#e98d58" }] }, { "featureType": "road.highway.controlled_access", "elementType": "geometry.stroke", "stylers": [{ "color": "#db8555" }] }, { "featureType": "road.local", "elementType": "labels.text.fill", "stylers": [{ "color": "#806b63" }] }, { "featureType": "transit", "stylers": [{ "visibility": "off" }] }, { "featureType": "transit.line", "elementType": "geometry", "stylers": [{ "color": "#dfd2ae" }] }, { "featureType": "transit.line", "elementType": "labels.text.fill", "stylers": [{ "color": "#8f7d77" }] }, { "featureType": "transit.line", "elementType": "labels.text.stroke", "stylers": [{ "color": "#ebe3cd" }] }, { "featureType": "transit.station", "elementType": "geometry", "stylers": [{ "color": "#dfd2ae" }] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "color": "#b9d3c2" }] }, { "featureType": "water", "elementType": "labels.text.fill", "stylers": [{ "color": "#92998d" }] }]
    });

    infowindow = new google.maps.InfoWindow({
        content: document.getElementById('form')
    })

    messagewindow = new google.maps.InfoWindow({
        content: document.getElementById('message')
    });



    google.maps.event.addListener(mappy, 'click', function (event) {
        console.log('got here')
        newmarker = new google.maps.Marker({
            position: event.latLng,
            map: mappy
        });

        google.maps.event.addListener(newmarker, "click", function () {
            infowindow.open(mappy, newmarker);
        });
    });

    talkToServer();
}


function initMapSingle(latValue, longValue) {
    let ulu = { lat: latValue, lng: longValue };
    mappy = new google.maps.Map(document.getElementById('map'), {
        zoom: 17,
        center: ulu,
        map: mappy
    });

    let singleMarker = new google.maps.Marker({
        position: ulu,
        map: mappy,
        icon: 'http://i.imgur.com/NBZi6ra.png'
    });

}



let talkToServer = () => {

    $.ajax({
        url: "/api/LandmarksAPI",
        dataType: "json",
        type: "GET",
        success: (data) => {

            //load marker data here 

            let markers = data.map((item) => {

                // Event that closes the Info Window with a click on the map
                //google.maps.event.addListener(map, 'click', function () {
                //    infowindow.close();
                //});



                let _m = new google.maps.Marker({
                    position: { lat: item.Latitude, lng: item.Longitude },
                    title: item.Title,
                    label: item.Title,
                    icon: 'http://i.imgur.com/NBZi6ra.png'
                });

                var tempor = item.Title;
                var contentString =
                    '<div id="content">' +
                    '<div id="siteNotice">' +
                    '</div>' +
                    '<h1 id="firstHeading" class="firstHeading">'+ item.Title +'</h1>' +
                    '<div id="bodytent">' + '<img src="' + item.Image1 + '" alt="' + item.Title +'" />' +
                    '<p>' + item.Description + '</p>' +
                    //'<a href= "' + item.Links + '" target="_blank"> More Info...</a>' +
                    '<a href= "/Home/LandmarkComments?id=' + item.Id + '" > More Info...</a>' +
                    '</div>' +
                    '</div>'

                  
                    ;

                let infowindow = new google.maps.InfoWindow({
                    content: contentString,
                    pixelOffset: new google.maps.Size(0, 0),
                    maxWidth: 700,

                });

                _m.addListener("click", function () {
                    //infowindow.close();
                    infowindow.open(mappy, _m);
                });

                google.maps.event.addListener(mappy, "click", function (event) {
                    console.log('clicked')
                    infowindow.close();
                });
                return _m;

            });

            let markerCluster = new MarkerClusterer(mappy, markers,
                { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });

            markers
        },
        error: (data) => {
            console.log("oops", data)
        }
    });
}




function saveData() {
    

    let title = $("#title").val();
    let description = $("#description").val();
    let userid = $("#userid").val();
    let categoryid = $("#categories").val();
    let latlng = newmarker.getPosition();
    let image = $('#image1').val();


    
    let that = this;
    $.ajax({
        url: "/api/LandmarksAPI",
        data: JSON.stringify({
            
            Title: title,
            Description: description,
            Latitude: latlng.lat(),
            Longitude: latlng.lng(),
            UserId: userid,
            Image1: image,
            CategoryId: parseInt(categoryid)
        }),
        contentType: "application/json",
        type: "POST",
        dataType: "json",
        success: (data) => {
            
            console.log('hello', data, that);
            infowindow.close();
        }
        
    });
    
}



function saveComment() {


    let userid = $("#userId").val();
    let landmarkid = $("#landmarkId").val();
    let usercomment = $("#userComment").val();
    $('#userComment').val('');
    

    $.ajax({
        url: "/home/addcomment",
        data: JSON.stringify({

            Body: usercomment,
            LandmarkId: parseInt(landmarkid),
            UserId: userid
        }),

        contentType: "application/json",
        method: "PUT",
        dataType: "html",
        success: (newHtml) => {

            
            $("#listOfComments").html(newHtml);
        }

    });

}






