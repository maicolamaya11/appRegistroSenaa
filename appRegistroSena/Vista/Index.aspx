<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/NavbarPrincipal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="appRegistroSena.Vista.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Carrusel.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section id="seccion12" class="section">
  
  <div class="slider">
    <div class="slider-slides">
      <div class="slider-slide active">
        <img src="Imagenes/jocvenes.jpg" alt="animals">
      </div>
      <div class="slider-slide">
        <img src="Imagenes/senacentro.png" alt="nature">
      </div>
    </div>
    <div class="slider-btns">
      <a class="prev" href="#">&laquo;</a>
      <a class="next" href="#">&raquo;</a>
    </div>
  </div>
</section>
    <script>
    const d = document;

d.addEventListener("DOMContentLoaded", (e) =>{
   slider();
});
function slider() {
  const $nextBtn = d.querySelector(".slider-btns .next"),
    $prevBtn = d.querySelector(".slider-btns .prev"),
    $slides = d.querySelectorAll(".slider-slide");

  let i = 0;
  d.addEventListener("click", (e) => {
    if (e.target === $prevBtn) {
      console.log(e.target);
      e.preventDefault();
      $slides[i].classList.remove("active");
      i--;

      if (i < 0) {
        i = $slides.length - 1;
      }

      $slides[i].classList.add("active");
    }

    if (e.target === $nextBtn) {
      e.preventDefault();
      $slides[i].classList.remove("active");
      i++;

      if (i > $slides.length - 1) {
        i = 0;
      }

      $slides[i].classList.add("active");
    }
  });
        }
    </script>
</asp:Content>
