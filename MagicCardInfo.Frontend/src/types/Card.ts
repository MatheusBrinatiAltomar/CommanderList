import { image_uri } from "./ImageURI";

export interface Card {
    id: string;
    name: string;
    oracle_text: string;
    mana_cost: string;
    type_line: string;
    scryfall_uri: string;
    image_uris: image_uri;
  }