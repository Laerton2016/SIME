<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SIME.Class.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script language="JavaScript">
    function proxima(link) {
        location.replace(link);
        return false;
    }
    function carrega(vobjeto) {
        for (var va = 0; va < document.forms[0].elements.length; va++) {
            if (document.forms[0].elements[va].name == vobjeto) {
                document.forms[0].elements[va].focus();
            }
        }
        return false;
    }
    function volta(vvolta) {
        history.go(vvolta * -1);
        return false;
    }
    function SaltaCampo(campo, prox, tammax, teclapres) {
        var tecla = teclapres.keyCode;
        vr = campo.value;
        tam = vr.length;
        if (tecla != 0 && tecla != 10 && tecla != 24)
            if (tam == tammax)
                prox.focus();
    }
</script>


<script>
    function html5_audio() {
        var a = document.createElement('audio');
        return !!(a.canPlayType && a.canPlayType('audio/wav;').replace(/no/, ''));
    }

    var play_html5_audio = false;
    if (html5_audio()) play_html5_audio = true;

    function play_sound(url) {

        if (play_html5_audio) {
            var snd = new Audio(url);
            snd.load();
            snd.play();
        } else {
            try {
                var soundEmbed = document.createElement("embed");
                soundEmbed.setAttribute("src", url);
                soundEmbed.setAttribute("hidden", true);
                soundEmbed.setAttribute("autostart", false);
                soundEmbed.setAttribute("width", 0);
                soundEmbed.setAttribute("height", 0);
                soundEmbed.setAttribute("enablejavascript", true);
                soundEmbed.setAttribute("autostart", true);
                document.body.appendChild(soundEmbed);
            }
            catch (e) {
                document.getElementById("captchaLink").setAttribute("href", url);

            }
        }
    }
</script>
<head runat="server">
    <title></title>
</head>
<script language=javascript>
    function validaCaracteresCaptcha(nomeForm, idLetra, idSom, paginaDestino) {
        var form = document.getElementById(nomeForm);
        if (document.getElementById(idLetra).value == "" && document.getElementById(idSom).value == "") {
            AlertaCaptcha("Favor preencher algum dos campos de validação");
            form.action = "";
            return false;
        }

        if (document.getElementById(idLetra).value != "" && document.getElementById(idSom).value != "") {
            AlertaCaptcha("Favor preencher apenas um dos campos de validação");
            form.action = "";
            return false;
        }
        if (document.getElementById("cnpj").value == "") {
            AlertaCaptcha("Favor preencher o campo de CNPJ");
            form.action = "";
            return false;
        }

        form.action = paginaDestino;
        return true;
    }

    function FRMOnLoad() {
        var ck
        ck = getCookie('flag');

        if (theForm.idLetra.value != "" || ck == null || ck == 1) {
            theForm.idLetra.value = "";  // para o firefox nao ficar recarregando em loop
            document.cookie = 'flag=0';
            location.reload();
        }
        theForm.cnpj.focus();
    }

    function Submeter() {

        document.cookie = 'flag=1';


        if (validaCaracteresCaptcha('theForm', 'captcha', 'captchaAudio', 'valida.asp') == false) {
            return false;
        }

    }

    function deleteCookie(nome) {
        var exdate = new Date();
        exdate.setTime(exdate.getTime() + (-1 * 24 * 3600 * 1000));
        document.cookie = nome + '=' + escape('') + ((-1 == null) ? '' : '; expires=' + exdate);
    }

    function getCookie(check_name) {
        // first we'll split this cookie up into name/value pairs
        // note: document.cookie only returns name=value, not the other components
        var a_all_cookies = document.cookie.split(';');
        var a_temp_cookie = '';
        var cookie_name = '';
        var cookie_value = '';
        var b_cookie_found = false; // set boolean t/f default f

        for (i = 0; i < a_all_cookies.length; i++) {
            // now we'll split apart each name=value pair
            a_temp_cookie = a_all_cookies[i].split('=');


            // and trim left/right whitespace while we're at it
            cookie_name = a_temp_cookie[0].replace(/^\s+|\s+$/g, '');

            // if the extracted name matches passed check_name
            if (cookie_name == check_name) {
                b_cookie_found = true;
                // we need to handle case where cookie has no value but exists (no = sign, that is):
                if (a_temp_cookie.length > 1) {
                    cookie_value = unescape(a_temp_cookie[1].replace(/^\s+|\s+$/g, ''));
                }
                // note that in cases where cookie is initialized but no value, null is returned
                return cookie_value;
                break;
            }
            a_temp_cookie = null;
            cookie_name = '';
        }
        if (!b_cookie_found) {
            return null;
        }
    }

				
	</script>
	
	<title>Emissão de Comprovante de Incrição e de Situação Cadastral</title>
	
	<script src="js/captcha.js" type="text/javascript"></script>
	<link href="css/captcha.css" rel="stylesheet" type="text/css" />
</head>


<body background="area_texto_back.jpg" onload="FRMOnLoad();">


<!--<form id="theForm" action="" onSubmit="javascript:return validaCaracteresCaptcha('theForm', 'idLetra', 'idSom', 'valida.asp')" method="post" name="frmConsulta">-->


<form id="theForm" action="" onSubmit="javascript:return Submeter();" method="post" name="frmConsulta">


	<table border="0" cellspacing="0" cellpadding="0" width="100%">
		<tr>
			<td>
				<font color="#000080" face="Arial">
				<b>Emissão de Comprovante de Inscrição e de Situação Cadastral</b></font>
			</td>  
		</tr>
	</table>
    
	<hr size="1">

	<p><font face="Arial" size="2">
	<b>Contribuinte,</b></p> 
	<p>Esta página tem como objetivo permitir a emissão do Comprovante de Inscrição e de Situação Cadastral 
	   de Pessoa Jurídica pela Internet em consonância com a 
	<!-- 23/06/2010 Jayro Martinelli SM:244814
	<a target="_blank" href="http://www.receita.fazenda.gov.br/Legislacao/Ins/2007/in7482007.htm">	
	<font face="Arial" size="2">
	Instrução Normativa RFB nº 748, de 28 de junho de 2007.</a> -->
	
	
	
	<a target="_blank" href="http://www.receita.fazenda.gov.br/Legislacao/Ins/2011/in11832011.htm">
	<font face="Arial" size="2">		
	Instrução Normativa RFB nº 1.183, de 19 de agosto de 2011.</a> 
	
	
	<p align="left"><font size="2" face="arial">
	Digite o número de CNPJ da empresa e clique em &quot;Consultar&quot;.</font></p>  

	<input type="hidden" name="origem" value="comprovante">    
	
	<input type=hidden id=viewstate name=viewstate value='RadStyleSheetManager1_TSSM=&RadScriptManager1_TSM=%3b%3bSystem.Web.Extensions%2c+Version%3d4.0.0.0%2c+Culture%3dneutral%2c+PublicKeyToken%3d31bf3856ad364e35%3aen-US%3acaf9918e-87b7-4f16-b8e8-f81c9ff8f4ab%3aea597d4b%3ab25378d2%3bTelerik.Web.UI%3aen-US%3a4701e229-f1c8-4ec4-9c40-b2d233d95d5d%3a16e4e7cd%3af7645509%3a22a6274a%3aed16cbdc%3a11e117d7&__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwUKLTc1OTk5NDIwOA8WAh4IcHJldkdVSUQFJGY1YmNlM2I4LTJiMzAtNGYyYy1hMGVmLTc4ZDEyZWViMTlkNxYCAgMPZBYCAgUPFCsAAw8WBh4FV2lkdGgbAAAAAADAckABAAAAHgZIZWlnaHQbAAAAAADAUkABAAAAHgRfIVNCAoADZBYCHgtDdXJyZW50R3VpZAUkZjViY2UzYjgtMmIzMC00ZjJjLWEwZWYtNzhkMTJlZWIxOWQ3FCsAA2RkFgIeCk1pblRpbWVvdXQCAxYCAgEPZBYIZg9kFgJmD2QWBmYPDxYKHwIbAAAAAAAASUABAAAAHwEbAAAAAACAZkABAAAAHghDc3NDbGFzc2UeCEltYWdlVXJsBVN%2BL1RlbGVyaWsuV2ViLlVJLldlYlJlc291cmNlLmF4ZD90eXBlPXJjYSZndWlkPWY1YmNlM2I4LTJiMzAtNGYyYy1hMGVmLTc4ZDEyZWViMTlkNx8DAoIDZGQCAQ8PFgIeBFRleHQFEUdlcmFyIG5vdmEgaW1hZ2VtZGQCAg8WBB4JaW5uZXJodG1sBQVPdXZpch4EaHJlZgVXfi9UZWxlcmlrLldlYi5VSS5XZWJSZXNvdXJjZS5heGQ%2FdHlwZT1jYWgmYW1wO2d1aWQ9ZjViY2UzYjgtMmIzMC00ZjJjLWEwZWYtNzhkMTJlZWIxOWQ3ZAIBDw8WCh8CGwAAAAAAAElAAQAAAB8BGwAAAAAAgGZAAQAAAB8GZR8HBVN%2BL1RlbGVyaWsuV2ViLlVJLldlYlJlc291cmNlLmF4ZD90eXBlPXJjYSZndWlkPWY1YmNlM2I4LTJiMzAtNGYyYy1hMGVmLTc4ZDEyZWViMTlkNx8DAoIDZGQCAg8WBh8JBQVPdXZpch8KBVd%2BL1RlbGVyaWsuV2ViLlVJLldlYlJlc291cmNlLmF4ZD90eXBlPWNhaCZhbXA7Z3VpZD1mNWJjZTNiOC0yYjMwLTRmMmMtYTBlZi03OGQxMmVlYjE5ZDceB1Zpc2libGVnZAIDD2QWBGYPDxYIHwZlHglBY2Nlc3NLZXllHghUYWJJbmRleAEAAB8DAgJkZAIBDw8WBh8GZR8IBRxUeXBlIHRoZSBjb2RlIGZyb20gdGhlIGltYWdlHwMCAmRkGAIFHl9fQ29udHJvbHNSZXF1aXJlUG9zdEJhY2tLZXlfXxYBBQtSYWRDYXB0Y2hhMQULUmFkQ2FwdGNoYTEPFCsAAgUkZjViY2UzYjgtMmIzMC00ZjJjLWEwZWYtNzhkMTJlZWIxOWQ3BgAAAAAAAAAAZEpCF3HYupB5QvUSWM83SKptN45FVZPv6aIjOua1y5HY&__EVENTVALIDATION=%2FwEWAgK6seaGBALYv5ykDAcIdx5vPZvcvXeSTErVEnGmoqyhahXjiPaJlRIhmHJ6&RadCaptcha1_ClientState=&RadCaptcha1%24CaptchaTextBox='> 
	
	<table border="0" cellspacing="1">
	<tr>
		<td valign="top" colspan="2">
		<font face="Arial" size="2">
		<b>CNPJ :</b> 
		<input 
			tabIndex="1" 
			name="cnpj" 
			maxlength="14" 
			size="16" 
			onKeyup="SaltaCampo(document.frmConsulta.cnpj, document.frmConsulta.chave, 14, event)"
			value=""> 
		</font>

		</td>
	</tr>
	
	
	
	<tr>
		<td valign="top" colspan="2">
		  
		</td>
	</tr>
	
	<tr>
		<td width="50%">
		  <font face="Arial" size="2">		  
			<span><label>Digite os caracteres ao lado:&nbsp;</label><input type='text' title='Repita os caracteres impressos na imagem ao lado ou pressione tab para acessar link de acessibilidade' maxLength='6' size='7' id='captcha' name='captcha'/><a id=captchaLink href='#' onclick="javascript:setTimeout(function(){play_sound('/scripts/captcha/Telerik.Web.UI.WebResource.axd?type=cah&amp;guid=f5bce3b8-2b30-4f2c-a0ef-78d12eeb19d7')}, 8000); document.getElementById('spanSom').style.display='block'; document.getElementById('captchaAudio').focus();"><img src='/scripts/captcha/captcha.gif' alt='Ouvir os caracteres'></a><span id='spanSom' style='display: none'><label for='captchaAudio'>Digite os caracteres que serão falados em breve:&nbsp;</label><input type='text' maxlength='6' size='7' id='captchaAudio' name='captchaAudio' onblur="document.getElementById('submit1').focus();"/></span></span>
		  </font>
		</td>
		<td width="50%">
		  <font face="Arial" size="2">
			<img border='0' id='imgcaptcha' alt='Imagem com os caracteres anti robô' src='/scripts/captcha/Telerik.Web.UI.WebResource.axd?type=rca&amp;guid=f5bce3b8-2b30-4f2c-a0ef-78d12eeb19d7'><br/>Se os caracteres da imagem estiverem ilegíveis, <a href="javascript:document.getElementById('captcha').value=''; window.location.reload();">gerar outra imagem</a>
		  </font>
		</td>
    </tr>
	
	
	
	<tr>
		<td align="center" colspan="2">
	    <p><br>
	    <input type="submit" value="Consultar" id=submit1 name=submit1>
	    <input type="hidden" name="search_type" value="cnpj">      
		<input type="reset" name="opcao" value="Limpar">

	    </p>
	    </td>
	</tr>
	</table>

	</form>
<!-- Div obrigatório. Nele será gravado o código necessário para funcionamento do flash-->
<div id="container"></div>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
