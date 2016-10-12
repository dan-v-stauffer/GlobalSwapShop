<%@ Control AutoEventWireup="true" Inherits="FVK.EnableResizable" %>
<script type="text/javascript">
    function ResizeIFrame() {
        if (graphApiInitialized != true) {
            setTimeout('ResizeIFrame()', 100);
            return;
        }
        FB.Canvas.setAutoResize();
    }
    ResizeIFrame();
</script>

