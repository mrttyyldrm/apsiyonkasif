import "@/styles/base.scss";
import Head from "next/head";
import Script from "next/script";
import { Plus_Jakarta_Sans } from "next/font/google";

export const metadata = {
  title: "Ana Sayfa | Apsiyon Kaşif",
  description:
    "Apsiyon Kaşif | Aspire Ekibi Apsiyon Proptech Hackathon Projesi",
};

export default function RootLayout({ children }) {
  return (
    <html lang="tr-TR">
      <Head>
        <link rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
        <link rel="preconnect" href="https://fonts.googleapis.com" />
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
        <link
          href="https://fonts.googleapis.com/css2?family=Plus+Jakarta+Sans:ital,wght@0,200..800;1,200..800&display=swap"
          rel="stylesheet"
        />
      </Head>
      <body>
        <main>{children}</main>
      </body>
      <Script src="https://kit.fontawesome.com/486aaf834f.js"></Script>
    </html>
  );
}
