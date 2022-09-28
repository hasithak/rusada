import { SightingMedia } from "./sighting-media";

export interface AirplaneSighting {
  id: number,
  make: string | null,
  model: string | null,
  registration: string | null,
  location: string,
  dateandTime: Date,
  mediaContent: string[],
  medias: SightingMedia[] | null
}
