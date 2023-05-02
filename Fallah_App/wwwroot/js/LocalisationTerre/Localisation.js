$(document).ready(function () {
    var map = null;
    var myMarker;
    var myLatlng;

    function initializeGMap(lat, lng) {
        myLatlng = new google.maps.LatLng(lat, lng);

        var myOptions = {
            zoom: 12,
            zoomControl: true,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

        myMarker = new google.maps.Marker({
            position: myLatlng
        });
        myMarker.setMap(map);
    }

    // Re-init map before show modal
    $('#myModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        initializeGMap(button.data('lat'), button.data('lng'));
        $("#location-map").css("width", "100%");
        $("#map_canvas").css("width", "100%");
    });

    // Trigger map resize event after modal shown
    $('#myModal').on('shown.bs.modal', function () {
        google.maps.event.trigger(map, "resize");
        map.setCenter(myLatlng);
    });
});
/*<script>
        function initMap() {
            var myLatLng = { lat: @Model.Latitude, lng: @Model.Longitude };

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 8,
                center: myLatLng
            });

            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                draggable: true,
                title: 'Positionnez votre localisation ici'
            });

            google.maps.event.addListener(marker, 'dragend', function (event) {
                document.getElementById('Latitude').value = this.getPosition().lat();
                document.getElementById('Longitude').value = this.getPosition().lng();
            });
        }
    </script>

    <script async defer src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap"></script>
}*/