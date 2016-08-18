/*

<script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
<script src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>

*/

var ticker = {
    loadingtext: '', 

    getajaxcontent: function($, config) {
        config.$ticker.html(this.loadingtext)
        $.ajax({
            url: config.msgsource,
            error: function(ajaxrequest) {
                config.$ticker.html('Server Response: ' + ajaxrequest.responseText)
            },
            success: function(content) {
                config.$ticker.html(content)
                ticker.setupticker(config)
            }
        })
    },

    rotate: function(config) {
        if (config.$ticker.get(0)._hoverstate == "over") {
            setTimeout(function() {
                ticker.rotate(config)
            }, config.rotatespeed)
        } else {
            config.$messages.eq(config.currentmsg).fadeOut(config.animateduration, function() {
                config.currentmsg = (config.currentmsg < config.$messages.length - 1) ? config.currentmsg + 1 : 0
                config.$messages.eq(config.currentmsg).fadeIn(config.animateduration, function() {
                    setTimeout(function() {
                        ticker.rotate(config)
                    }, config.rotatespeed)
                })
            })
        }
    },

    getCookie: function(Name) {
        var re = new RegExp(Name + "=[^;]+", "i")
        if (document.cookie.match(re)) 
            return document.cookie.match(re)[0].split("=")[1]
        return null
    },

    setCookie: function(name, value) {
        document.cookie = name + "=" + value
    },

    setupticker: function(config) {
        config.$messages = config.$ticker.find('div.' + config.msgclass).hide()
        config.currentmsg = Math.min(parseInt(ticker.getCookie(config.id) || 0), config.$messages.length - 1)
        config.$messages.hide().eq(config.currentmsg).fadeIn(config.animateduration)
        setTimeout(function() {
           ticker.rotate(config)
        }, config.rotatespeed)
        $(window).bind('unload', function() {
            ticker.cleanup(config)
        })
    },

    define: function(config) {
        jQuery(document).ready(function($) {
            config.$ticker = $('#' + config.id)
            if (config.$ticker.length == 0)
                return
            config.$ticker.css({
                overflow: 'hidden'
            }).hover(
                function() {
                    this._hoverstate = "over"
                },
                function() {
                    this._hoverstate = "out"
                }
            )
            if (config.msgsource == "inline") {
                ticker.setupticker(config)
            } else {
                ticker.getajaxcontent($, config)
            }
        })
    },

    cleanup: function(config) {
        this.setCookie(config.id, config.currentmsg)
    }

}



ticker.define({
    id: "tickerContainer",      
    msgclass: "messagediv",     
    msgsource: "inline",        
    rotatespeed: 3000,          
    animateduration: 1000       
})
