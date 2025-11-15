document.addEventListener("DOMContentLoaded", function () {
  const sidebar = document.getElementById("sidebar");
  const header = document.getElementById("header");
  const footer = document.getElementById("footer");
  const content = document.getElementById("content");

  const pages = [
    { url: "index.html", title: "Home" },
    { url: "01.html", title: "FAQ" },
    { url: "02.html", title: "Starting off" },
    { url: "03.html", title: "General" },
    { url: "04.html", title: "Menu bar" },
    { url: "05.html", title: "Training" },
    { url: "06.html", title: "Alchemy" },
    { url: "07.html", title: "Lure" },
    { url: "08.html", title: "Trade" },
    { url: "09.html", title: "Skills" },
    { url: "10.html", title: "Protection" },
    { url: "11.html", title: "Party" },
    { url: "12.html", title: "Inventory" },
    { url: "13.html", title: "Items" },
    { url: "14.html", title: "Map" },
    { url: "15.html", title: "Statistics" },
    { url: "16.html", title: "Chat" },
    { url: "17.html", title: "Log" },
  ];

  // Header
  header.classList.add("sticky-top");
  header.innerHTML = `
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark navbar-custom">
        <div class="container-fluid">
            <a class="navbar-brand" href="index.html">
                <img src="assets/app.ico" alt="RSBot Icon" width="30" height="24" class="d-inline-block align-text-top">
                RSBot
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="communityDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Community
                        </a>
                        <ul class="dropdown-menu" aria-labelledby="communityDropdown">
                            <li><a class="dropdown-item" href="https://discord.gg/MuY5ejEU3r" target="_blank">Discord</a></li>
                            <li><a class="dropdown-item" href="https://github.com/SDClowen/RSBot" target="_blank">GitHub</a></li>
                        </ul>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="releasesDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Releases
                        </a>
                        <ul class="dropdown-menu" aria-labelledby="releasesDropdown">
                            <li><a class="dropdown-item" href="https://github.com/SDClowen/RSBot/releases/latest" target="_blank">Latest Stable</a></li>
                            <li><a class="dropdown-item" href="https://github.com/SDClowen/RSBot/releases" target="_blank">Nightly</a></li>
                            <li><a class="dropdown-item" href="https://github.com/warofmine/Rsbot-Manager/releases/latest" target="_blank">Manager</a></li>
                        </ul>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="projectDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Project
                        </a>
                        <ul class="dropdown-menu" aria-labelledby="projectDropdown">
                            <li><a class="dropdown-item" href="https://github.com/SDClowen/RSBot" target="_blank">GitHub Repo</a></li>
                            <li><a class="dropdown-item" href="https://github.com/SDClowen/RSBot/blob/master/LICENSE" target="_blank">License</a></li>
                            <li><a class="dropdown-item" href="https://app.fossa.com/projects/git%2Bgithub.com%2FSDClowen%2FRSBot?ref=badge_shield" target="_blank">FOSSA</a></li>
                        </ul>
                    </li>
                     <li class="nav-item">
                        <a class="nav-link" href="https://buymeacoffee.com/sdclowen" target="_blank">Donate</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    `;

  // Sidebar
  let sidebarHTML = '<nav class="nav flex-column nav-pills">';
  const currentPage = window.location.pathname.split("/").pop();

  pages.forEach((page) => {
    sidebarHTML += `
            <a class="nav-link ${currentPage === page.url ? "active" : ""}" href="${page.url}">${page.title}</a>
        `;
  });
  sidebarHTML += "</nav>";
  sidebar.innerHTML = sidebarHTML;

  // Footer
  footer.innerHTML = `
        <div class="container-fluid">
            <p>&copy; 2025 RSBot. All rights reserved.</p>
        </div>
    `;

  // Admonition Renderer
  const admonitionMap = {
    "[!NOTE]": "note",
    "[!TIP]": "tip",
    "[!IMPORTANT]": "important",
    "[!WARNING]": "warning",
    "[!CAUTION]": "caution",
  };

  document.querySelectorAll("blockquote").forEach((blockquote) => {
    const p = blockquote.querySelector("p");
    if (p) {
      const text = p.innerHTML.trim();
      const admonitionType = Object.keys(admonitionMap).find((key) => text.startsWith(key));
      if (admonitionType) {
        const admonitionClass = admonitionMap[admonitionType];
        const admonitionTitle = admonitionType.replace("[!", "").replace("]", "");
        const content = text.substring(admonitionType.length).trim();

        const newAdmonition = document.createElement("div");
        newAdmonition.className = `admonition ${admonitionClass}`;
        newAdmonition.innerHTML = `<p class="admonition-title">${admonitionTitle}</p><p>${content}</p>`;

        blockquote.parentNode.replaceChild(newAdmonition, blockquote);
      }
    }
  });
});
