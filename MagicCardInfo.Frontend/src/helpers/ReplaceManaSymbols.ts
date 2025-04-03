export function replaceManaSymbols(text: string): string {
    const manaImages = {
          //Numbers
          "{1}": "/images/1_generic.svg",
          "{2}": "/images/2_generic.svg",
          "{3}": "/images/3_generic.svg",
          "{4}": "/images/4_generic.svg",
          "{5}": "/images/5_generic.svg",
          "{6}": "/images/6_generic.svg",
          "{7}": "/images/7_generic.svg",
          "{8}": "/images/8_generic.svg",
          "{9}": "/images/9_generic.svg",
          "{10}": "/images/10_generic.svg",
          "{11}": "/images/11_generic.svg",
          "{12}": "/images/12_generic.svg",
          "{13}": "/images/13_generic.svg",
          "{14}": "/images/14_generic.svg",
          "{15}": "/images/15_generic.svg",
          //Single Mana Pips
          "{R}": "/images/red_mana.svg",
          "{G}": "/images/green_mana.svg",
          "{U}": "/images/blue_mana.svg",
          "{B}": "/images/black_mana.svg",
          "{W}": "/images/white_mana.svg",
          "{C}": "/images/colorless_mana.svg",
          "{S}": "/images/snow_mana.svg",
          "{X}": "/images/x_generic.svg",
          "{W/P}": "/images/white_phyrexian_mana.svg",
          "{U/P}": "/images/blue_phyrexian_mana.svg",
          "{B/P}": "/images/black_phyrexian_mana.svg",
          "{R/P}": "/images/red_phyrexian_mana.svg",
          "{G/P}": "/images/green_phyrexian_mana.svg",
          //Dual Mana Pips
          "{W/U}": "/images/white_blue_mana.svg",
          "{W/B}": "/images/white_black_mana.svg",
          "{B/R}": "/images/black_red_mana.svg",
          "{B/G}": "/images/black_green_mana.svg",
          "{U/B}": "/images/blue_black_mana.svg",
          "{U/R}": "/images/blue_red_mana.svg",
          "{R/G}": "/images/red_green_mana.svg",
          "{R/W}": "/images/red_white_mana.svg",
          "{G/W}": "/images/green_white_mana.svg",
          "{G/U}": "/images/green_blue_mana.svg",
          "{C/W}": "/images/colorless_white_mana.png",
          "{C/U}": "/images/colorless_blue_mana.png",
          "{C/B}": "/images/colorless_black_mana.png",
          "{C/R}": "/images/colorless_red_mana.png",
          "{C/G}": "/images/colorless_green_mana.png",
          "{2/W}": "/images/2_generic_white_mana.svg",
          "{2/U}": "/images/2_generic_blue_mana.svg",
          "{2/B}": "/images/2_generic_black_mana.svg",
          "{2/R}": "/images/2_generic_red_mana.svg",
          "{2/G}": "/images/2_generic_green_mana.svg",
          //Symbols
          "{T}": "/images/tap_symbol.svg",
          "{E}": "/images/energy.svg",
          "{A}": "/images/acorn_counter.svg",
      };

      return text.replace(/\{([AERGBWUCXT]|[1-9]|1[0-5]|[2RGBWUC]\/[RGBWUP])\}/g, match => {
          return manaImages[match] ? `<img src="${manaImages[match]}" alt="${match}" class="inline-block w-5 h-5 pr-0.5" />` : match;
      });
  }