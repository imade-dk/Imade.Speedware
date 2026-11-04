import { customElement } from '@umbraco-cms/backoffice/external/lit';
import { SpeedwarePickerBaseElement } from '../speedware-picker.element.js';
import { ImadeSpeedwareWebService } from '../../api/index.js';
import type { PickerItem } from '../types.js';

@customElement('imade-speedware-rooms-picker')
export class RoomsPickerElement extends SpeedwarePickerBaseElement {
	protected readonly localizationKey = 'speedwareRoomsPicker';

	protected async fetchItems(): Promise<PickerItem[]> {
		const { data } = await ImadeSpeedwareWebService.getRooms({ throwOnError: true });
		return data.map((r) => ({ id: r.id, label: r.name }));
	}
}

export default RoomsPickerElement;

declare global {
	interface HTMLElementTagNameMap {
		'imade-speedware-rooms-picker': RoomsPickerElement;
	}
}
